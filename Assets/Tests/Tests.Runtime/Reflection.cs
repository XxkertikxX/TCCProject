using System;
using System.Reflection;

public static class Reflection
{
    public static void SetField(object targetObject, string fieldName, object value) {
        var field = GetFieldRecursive(targetObject.GetType(), fieldName);
        field.SetValue(targetObject, value);
    }

    public static T GetField<T>(object targetObject, string fieldName) {
        var field = GetFieldRecursive(targetObject.GetType(), fieldName);
        return (T)field.GetValue(targetObject);
    }

    private static FieldInfo GetFieldRecursive(Type type, string fieldName) {
        while (type != null) {
            var field = type.GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            if (field != null) return field;
            type = type.BaseType;
        }

        throw new ArgumentException($"Campo '{fieldName}' não encontrado na hierarquia.");
    }
}