using LiteDB;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveSystem
{
    public void Save() {
        using (var db = new LiteDatabase(Path())) {
            var col = db.GetCollection<SaveStats>("save_stats");
            col.Upsert(Update(db));
        }
    }
    
    public void SaveBattle(int index, bool win) {
        using (var db = new LiteDatabase(Path())) {
            var col = db.GetCollection<SaveStats>("save_stats");
            col.Upsert(UpdateBattles(db, index, win));
        } 
    }

    public SaveStats OpenLoad() {
        using (var db = new LiteDatabase(Path())) {
            return Load(db);
        }
    }

    private SaveStats Load(LiteDatabase db) {
        var col = db.GetCollection<SaveStats>("save_stats");
		var save = col.FindOne(Query.EQ("ID", 1));
		if(save == null) {
		    save = CreateNew();
			col.Upsert(save);
		}
		return save;
    }

    private SaveStats CreateNew() {
        var save = new SaveStats {
            ID = 1,
            SceneName = "Tutorial1",
            ManaBase = 10,
            Level = 0,
            Player = NewVector3(-4.5f,-1.33f,0),
            DefeatEnemy = new bool[]{false, false}
        };
		save.ManaTotal = save.ManaBase + save.Level;
        return save;
    }   

    private SaveStats Update(LiteDatabase db) {
		Transform player = GameObject.FindGameObjectWithTag("Player").transform;

		SaveStats save = Load(db);

		save.SceneName = SceneManager.GetActiveScene().name;
		save.Level = LevelSystem.Level;
		save.Player = NewVector3(player.position.x, player.position.y, player.position.z);
		save.ManaTotal = save.ManaBase + save.Level;

		return save;
    }

    private SaveStats UpdateBattles(LiteDatabase db, int index, bool win) {
        SaveStats save = Load(db);
        save.DefeatEnemy[index] = !win;
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