using System.Collections.Generic;
using UnityEngine;
using LiteDB;

public class Bindings : MonoBehaviour
{
    private Dictionary<string, KeyCode> bindingsDic;
    public Dictionary<string, KeyCode> BindingsDic => bindingsDic;

    void OnEnable() {
        ChangeBinding.OnBindingChanged += UpdateBindings;
    }
    
    void OnDisable() {
        ChangeBinding.OnBindingChanged -= UpdateBindings;
    }
    
    void Start() {
        UpdateBindings();
    }

    private void UpdateBindings() {
        string path = Application.persistentDataPath + "/bindings.db";
        using (var db = new LiteDatabase(path)) {
            ResetDictionary();
            UpdateDictionary(db);
        }
    }

    private void ResetDictionary() {
        bindingsDic = new Dictionary<string, KeyCode>();
    }

    private void UpdateDictionary(LiteDatabase db) {
        foreach (var binding in Col(db).FindAll()) {
            bindingsDic.Add(binding.KeyName, binding.Key);
        }
    }

    private ILiteCollection<KeyBinding> Col(LiteDatabase db) {
        return db.GetCollection<KeyBinding>("bindings");
    }
}