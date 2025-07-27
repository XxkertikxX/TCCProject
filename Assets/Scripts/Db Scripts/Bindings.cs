using System.Collections.Generic;
using UnityEngine;
using LiteDB;

public class Bindings : MonoBehaviour
{
    public Dictionary<string, KeyCode> BindingsDic;

    void OnEnable() {
        ChangeBinding.OnBindingChanged += UpdateBindings;
    }
    
    void OnDisable() {
        ChangeBinding.OnBindingChanged -= UpdateBindings;
    }
    
    private void UpdateBindings() {
        string path = Application.persistentDataPath + "/bindings.db";
        using (var db = new LiteDatabase(path)) {
            ResetDictionary();
            UpdateDictionary(db);
        }
    }

    private void ResetDictionary() {
        BindingsDic = new Dictionary<string, KeyCode>();
    }

    private void UpdateDictionary(LiteDatabase db) {
        foreach (var binding in Col(db).FindAll()) {
            BindingsDic.Add(binding.KeyName, binding.Key);
        }
    }

    private ILiteCollection<KeyBinding> Col(LiteDatabase db) {
        return db.GetCollection<KeyBinding>("bindings");
    }
}