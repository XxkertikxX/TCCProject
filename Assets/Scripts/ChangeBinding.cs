using UnityEngine;
using LiteDB;

public class ChangeBinding : MonoBehaviour
{
    public IEnumerator WaitClick(string KeyName) {
        yield return new WaitForAnyKeyDown();

        KeyCode Key = PressKey();
        
        Binding(KeyName, Key);
    }
    
    void Binding(string KeyName, KeyCode keyCode){
        using (var db = new LiteDatabase("bindings.db")) {
            var col = db.GetCollection<KeyBinding>("bindings");

            var bind = new KeyBinding {
                keyName = KeyName,
                key = keyCode
            };

            col.Upsert(bind);
        }
    }

    KeyCode PressKey(){
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