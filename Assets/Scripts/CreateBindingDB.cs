using UnityEngine;
using LiteDB;

public class CreateBindingDB : MonoBehaviour
{
    void Start(){
        var path = Application.persistentDataPath + "/bindings.db";

        if (System.IO.File.Exists(path)) {
            System.IO.File.Delete(path);
        }

        using (var db = new LiteDatabase(path)) {
                
            var col = db.GetCollection<KeyBinding>("bindings");

            col.Upsert(new KeyBinding { KeyName = "Jump", Key = KeyCode.Space });
        }
    }
}
