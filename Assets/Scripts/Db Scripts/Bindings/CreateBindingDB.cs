using UnityEngine;
using LiteDB;

public class CreateBindingDB : MonoBehaviour
{
    void Awake() {
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
        CreateKey("Jump", col, KeyCode.Space);
        CreateKey("Left", col, KeyCode.A, KeyCode.LeftArrow);
        CreateKey("Right", col, KeyCode.D, KeyCode.RightArrow);
        CreateKey("Up", col, KeyCode.W, KeyCode.UpArrow);
        CreateKey("Down", col, KeyCode.S, KeyCode.DownArrow);
        CreateKey("Run", col, KeyCode.LeftShift);
        CreateKey("Interact", col, KeyCode.E);
        CreateKey("Skip", col, KeyCode.Space);
        CreateKey("Menu", col, KeyCode.Escape);
        CreateKey("Return", col, KeyCode.X);
        CreateKey("Save", col, KeyCode.F5);
    }

	private void CreateKey(string keyName, ILiteCollection<KeyBinding> col, params KeyCode[] keys) {
		col.Upsert(new KeyBinding { 
			KeyName = keyName, 
			Keys = keys
		});
	}
}