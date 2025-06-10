using System.Collections.Generic;
using UnityEngine;
using LiteDB;

public class Bindings : MonoBehaviour
{
    public static Dictionary<string, KeyCode> bindings;

    static public void UpdateBindings() {
        string path = Application.persistentDataPath + "/bindings.db";
        using (var db = new LiteDatabase(path)) {
            ResetDictionary();
            UpdateDictionary(db);
        }
    }

    static void ResetDictionary() {
        bindings = new Dictionary<string, KeyCode>();
    }

    static void UpdateDictionary(LiteDatabase db) {
        foreach (var binding in Col(db).FindAll()) {
            bindings.Add(binding.keyName, binding.key);
        }
    }

    static ILiteCollection<KeyBinding> Col(LiteDatabase db) {
        return db.GetCollection<KeyBinding>("bindings");
    }
}