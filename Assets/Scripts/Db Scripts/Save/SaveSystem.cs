using LiteDB;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveSystem
{
    public void Save() {
        using (var db = new LiteDatabase(Path())) {
            var col = db.GetCollection<SaveStats>("save_stats");
            col.Upsert(Update());
        }
    }
    
    public SaveStats Load() {
        using (var db = new LiteDatabase(Path())) {
            var col = db.GetCollection<SaveStats>("save_stats");
			var save = col.FindOne(Query.EQ("ID", 1));
			if(save == null) {
				save = CreateNew();
				col.Upsert(save);
			}
			return save;
        }
    }

    private SaveStats CreateNew() {
        var save = new SaveStats {
            ID = 1,
            SceneName = "Tutorial1",
            ManaBase = 10,
            Level = 0,
            Player = NewVector3(-4.5f,-1.33f,0)
        };
		save.ManaTotal = save.ManaBase + save.Level;
        return save;
    }   

    private SaveStats Update() {
		Transform player = GameObject.FindGameObjectWithTag("Player").transform;

		SaveStats save = Load();

		save.SceneName = SceneManager.GetActiveScene().name;
		save.Level = LevelSystem.Level;
		save.Player = NewVector3(player.position.x, player.position.y, player.position.z);
		save.ManaTotal = save.ManaBase + save.Level;

		return save;
    }

    private Vector3Stat NewVector3(float x, float y, float z) {
        Vector3Stat vector3 = new Vector3Stat();
        vector3.X = x;
        vector3.Y = y;
        vector3.Z = z;
        return vector3;
    }

    private string Path() {
        return Application.persistentDataPath + "/save_stats.db";
    }
}