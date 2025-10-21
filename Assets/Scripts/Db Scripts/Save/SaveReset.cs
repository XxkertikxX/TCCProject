using UnityEngine;
using LiteDB;

public class SaveReset : MonoBehaviour
{
    void Awake() {
		if (System.IO.File.Exists(Path())) {
            System.IO.File.Delete(Path());
        }
	}
	
	private string Path() {
        return Application.persistentDataPath + "/save_stats.db";
    }
}
