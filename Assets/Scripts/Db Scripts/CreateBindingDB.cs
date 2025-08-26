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

    private void DestroyExistentDB(){
        if (System.IO.File.Exists(Path())) {
            System.IO.File.Delete(Path());
        }
    }

    private string Path() {
        return Application.persistentDataPath + "/bindings.db";
    }

    private void CreateKeys(ILiteCollection<KeyBinding> col){
        CreateKey("Jump", KeyCode.Space, col);
        CreateKey("Left", KeyCode.A, col);
        CreateKey("Right", KeyCode.D, col);
        CreateKey("Run", KeyCode.LeftShift, col);
        CreateKey("Interact", KeyCode.E, col);
        CreateKey("Skip", KeyCode.Return, col);
        CreateKey("Menu", KeyCode.Escape, col);
        CreateKey("Down",KeyCode.DownArrow, col);
        CreateKey("Up", KeyCode.UpArrow, col);
        CreateKey("Left2", KeyCode.LeftArrow, col);
        CreateKey("Right2", KeyCode.RightArrow, col);
        CreateKey("Return", KeyCode.X, col);
    }

    private void CreateKey(string KeyName, KeyCode Key, ILiteCollection<KeyBinding> col)
    {
        col.Upsert(new KeyBinding { KeyName = KeyName, Key = Key});
    }
}