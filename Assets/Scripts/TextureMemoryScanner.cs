using System.Collections.Generic;
using UnityEngine;

public class TextureMemoryScanner : MonoBehaviour
{
    [ContextMenu("Scan Loaded Textures")]
    public void ScanTextures()
    {
        // Dicionário: Key = nome da textura, Value = info de contagem e tamanho aproximado
        Dictionary<string, (int count, int approxBytes)> textureStats = new Dictionary<string, (int, int)>();

        // Procura todas as Texture2D carregadas na memória
        Texture2D[] textures = Resources.FindObjectsOfTypeAll<Texture2D>();

        foreach (var tex in textures)
        {
            if (tex == null) continue;

            string name = tex.name;
            int sizeBytes = tex.width * tex.height * 4; // aprox em bytes (RGBA32)
            
            if (textureStats.ContainsKey(name))
            {
                var entry = textureStats[name];
                textureStats[name] = (entry.count + 1, entry.approxBytes + sizeBytes);
            }
            else
            {
                textureStats[name] = (1, sizeBytes);
            }
        }

        Debug.Log("=== Texture Memory Scan Result ===");
        foreach (var kvp in textureStats)
        {
            string name = kvp.Key;
            int count = kvp.Value.count;
            float mb = kvp.Value.approxBytes / (1024f * 1024f);
            if(mb > 1 || count > 1) {
                Debug.Log($"Texture: {name}, Instances: {count}, Approx. Size: {mb:F2} MB");
            }
        }

        Debug.Log($"Total Textures Found: {textures.Length}");
        Debug.Log("=== End of Scan ===");
    }
}