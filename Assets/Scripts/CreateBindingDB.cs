using UnityEngine;
using LiteDB;

public class CreateBindingDB : MonoBehaviour
{
    void Start() {
        using (var db = new LiteDatabase(Path())) {
            DestroyExistentDB();
            var col = db.GetCollection<KeyBinding>("bindings");
            CreateKeys(col);
        }
    }
    void DestroyExistentDB(){
        if (System.IO.File.Exists(Path())) {
            System.IO.File.Delete(Path());
        }
    }

    string Path() {
        return Application.persistentDataPath + "/bindings.db";
    }

    void CreateKeys(ILiteCollection<KeyBinding> col){
        col.Upsert(new KeyBinding { keyName = "Jump", key = KeyCode.Space });
        col.Upsert(new KeyBinding { keyName = "Left", key = KeyCode.A });
        col.Upsert(new KeyBinding { keyName = "Right", key = KeyCode.D });
    }
}
