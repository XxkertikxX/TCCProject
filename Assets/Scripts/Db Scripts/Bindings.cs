using System.Collections.Generic;
using UnityEngine;
using LiteDB;

public class Bindings : MonoBehaviour
{
    public static Dictionary<string, KeyCode> BindingsDic;

    static public void UpdateBindings() {
        string path = Application.persistentDataPath + "/bindings.db";
        using (var db = new LiteDatabase(path)) {
            ResetDictionary();
            UpdateDictionary(db);
        }
    }

    static private void ResetDictionary() {
        BindingsDic = new Dictionary<string, KeyCode>();
    }

    static private void UpdateDictionary(LiteDatabase db) {
        foreach (var binding in Col(db).FindAll()) {
            BindingsDic.Add(binding.KeyName, binding.Key);
        }
    }

    static private ILiteCollection<KeyBinding> Col(LiteDatabase db) {
        return db.GetCollection<KeyBinding>("bindings");
    }
}