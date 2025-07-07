using UnityEngine;
using LiteDB;

public class CreateBindingDB : MonoBehaviour
{
    void Start() {
        DestroyExistentDB();
        using (var db = new LiteDatabase(Path())) {
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
        CreateKey("Jump", KeyCode.Space, col);
        CreateKey("Left", KeyCode.A, col);
        CreateKey("Right", KeyCode.D, col);
    }

    void CreateKey(string KeyName, KeyCode Key, ILiteCollection<KeyBinding> col) {
        col.Upsert(new KeyBinding { keyName = KeyName, key = Key});
    }
}