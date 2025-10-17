using System;
using System.Reflection;
using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class FilteredStaticUnityScanner : EditorWindow
{
    [MenuItem("Tools/Filtered Static Unity Scanner")]
    public static void ShowWindow()
    {
        GetWindow<FilteredStaticUnityScanner>("Filtered Static Unity Scanner");
    }

    private Vector2 scrollPos;
    private List<string> report = new List<string>();

    private static readonly string[] ignoreAssemblies = new string[]
    {
        "UnityEngine", "UnityEditor", "Unity.", "TMPro", "TextMeshPro", "Cinemachine",
        "Unity.2D", "Unity.Addressables", "Unity.RenderPipelines", "Unity.VisualScripting",
        "Unity.Mathematics", "Unity.InputSystem", "Unity.Timeline", "Unity.PostProcessing"
    };

    private void OnGUI()
    {
        if (GUILayout.Button("Scan Project (Filtered)"))
        {
            report.Clear();
            ScanFilteredStaticUnityReferences();
        }

        scrollPos = GUILayout.BeginScrollView(scrollPos);
        foreach (string line in report)
        {
            GUILayout.Label(line);
        }
        GUILayout.EndScrollView();
    }

    private void ScanFilteredStaticUnityReferences()
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();

        foreach (var assembly in assemblies)
        {
            // Ignora assemblies da Unity e pacotes comuns
            string asmName = assembly.FullName;
            bool ignore = false;
            foreach (var ignoreStr in ignoreAssemblies)
            {
                if (asmName.StartsWith(ignoreStr, StringComparison.OrdinalIgnoreCase))
                {
                    ignore = true;
                    break;
                }
            }
            if (ignore) continue;

            Type[] types;
            try { types = assembly.GetTypes(); } catch { continue; }

            foreach (var type in types)
            {
                FieldInfo[] fields;
                try
                {
                    fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
                }
                catch { continue; }

                foreach (var field in fields)
                {
                    Type fieldType = field.FieldType;

                    // Ignora primitivos e structs simples
                    if (fieldType.IsPrimitive || fieldType.IsEnum || fieldType == typeof(string))
                        continue;

                    // Filtro principal: apenas tipos Unity ou derivados
                    if (typeof(UnityEngine.Object).IsAssignableFrom(fieldType) ||
                        typeof(GameObject).IsAssignableFrom(fieldType) ||
                        typeof(Component).IsAssignableFrom(fieldType))
                    {
                        string access = field.IsPublic ? "Public" : "Non-Public";
                        string line = $"[Static Unity Ref] {type.FullName}.{field.Name} ({fieldType.Name}) [{access}]";
                        Debug.Log(line);
                        report.Add(line);
                    }

                    // Genéricos contendo tipos Unity
                    else if (fieldType.IsGenericType)
                    {
                        foreach (var arg in fieldType.GetGenericArguments())
                        {
                            if (typeof(UnityEngine.Object).IsAssignableFrom(arg))
                            {
                                string access = field.IsPublic ? "Public" : "Non-Public";
                                string line = $"[Static Unity Ref (Generic)] {type.FullName}.{field.Name} ({fieldType.Name}<{arg.Name}>) [{access}]";
                                Debug.Log(line);
                                report.Add(line);
                            }
                        }
                    }
                }
            }
        }

        Debug.Log("=== Filtered Static Unity Reference Scan Finished ===");
    }
}