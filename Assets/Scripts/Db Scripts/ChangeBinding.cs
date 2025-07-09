using UnityEngine;
using System.Collections;
using LiteDB;

public class ChangeBinding : MonoBehaviour
{
    public IEnumerator WaitClick(string keyName) {
        yield return new WaitForAnyKeyDown();

        KeyCode key = PressKey();
        
        Binding(keyName, key);
    }
    
    private void Binding(string keyName, KeyCode keyCode){
        using (var db = new LiteDatabase("bindings.db")) {
            var col = db.GetCollection<KeyBinding>("bindings");

            var bind = new KeyBinding {
                KeyName = keyName,
                Key = keyCode
            };

            col.Upsert(bind);
        }
    }

    private KeyCode PressKey(){
        foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode))) {
            if (Input.GetKeyDown(key))
                return key;
        }
        return KeyCode.None;
    }
}

public class WaitForAnyKeyDown : CustomYieldInstruction {
    public override bool keepWaiting {
        get {
            return !Input.anyKeyDown; 
        }
    }
}