using LiteDB;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveSystem
{
    public void Save(int level) {
        using (var db = new LiteDatabase(Path())) {
            var col = db.GetCollection<SaveStats>("save_stats");
            col.Upsert(Update(level));
        }
    }

    public SaveStats CreateNew() {
        SaveStats newSaveStats = new SaveStats();
        newSaveStats.ID = 1;
        newSaveStats.SceneName = "Tutorial1";
        newSaveStats.ManaBase = 10;
        newSaveStats.Level = 0;
        newSaveStats.ManaTotal = newSaveStats.ManaBase + newSaveStats.Level;
        newSaveStats.Player = NewVector3(0, 0, 0);
        return newSaveStats;
    }   

    public SaveStats Load() {
        using (var db = new LiteDatabase(Path())) {
            var col = db.GetCollection<SaveStats>("save_stats");
            return col.FindOne(Query.All());
        }
    }

    public SaveStats Update(int level) {
        SaveStats newSaveStats = new SaveStats();
        newSaveStats.ID = 1;
        newSaveStats.SceneName = SceneManager.GetActiveScene().name;
        newSaveStats.ManaBase = 10;
        newSaveStats.Level = level;
        newSaveStats.ManaTotal = newSaveStats.ManaBase + newSaveStats.Level;
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        newSaveStats.Player = NewVector3(player.position.x, player.position.y, player.position.z);
        return newSaveStats;
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