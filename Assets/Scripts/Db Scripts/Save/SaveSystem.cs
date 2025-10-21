using LiteDB;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveSystem
{
    public void Save() {
        using (var db = new LiteDatabase(Path())) {
            var col = db.GetCollection<SaveStats>("save_stats");
            var save = Load(db);
            SaveStatusCharacter.LoadStatus(save);
            save = Update(save);
            col.Upsert(save);
        }
    }

    public void SaveBattle(int index, bool win) {
        using (var db = new LiteDatabase(Path())) {
            var col = db.GetCollection<SaveStats>("save_stats");
            var save = Load(db);
            save = UpdateBattles(save, index, win);
            col.Upsert(save);
        }
    }

    public SaveStats OpenLoad() {
        using (var db = new LiteDatabase(Path())) {
            return Load(db);
        }
    }

    public SaveStats Load(LiteDatabase db) {
        var col = db.GetCollection<SaveStats>("save_stats");
        var save = col.FindOne(Query.EQ("_id", 1));
        if (save == null) {
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
            Player = NewVector3(-4.5f, -1.33f, 0),
            DefeatEnemy = new bool[] { false, false }
        };
        save.ManaTotal = save.ManaBase + save.Level;
        SaveStatusCharacter.SaveStatus(save);
        return save;
    }

    private SaveStats Update(SaveStats save) {
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;

        save.SceneName = SceneManager.GetActiveScene().name;
        save.Level = LevelSystem.Level;
        save.Player = NewVector3(player.position.x, player.position.y, player.position.z);
        save.ManaTotal = save.ManaBase + save.Level;
        SaveStatusCharacter.SaveStatus(save);
        return save;
    }

    private SaveStats UpdateBattles(SaveStats save, int index, bool win) {
        save.DefeatEnemy[index] = win;
        return save;
    }

    private Vector3Stat NewVector3(float x, float y, float z) {
        return new Vector3Stat { X = x, Y = y, Z = z };
    }

    private string Path() {
        return Application.persistentDataPath + "/save_stats.db";
    }
}