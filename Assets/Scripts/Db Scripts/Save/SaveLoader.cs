using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoader : MonoBehaviour
{
    void Start() {
        SaveSystem saveSystem = new SaveSystem();
        CreateNewSaveIfNotExists(saveSystem);
        LoadSave(saveSystem);
    }

    private void CreateNewSaveIfNotExists(SaveSystem saveSystem) {
        if (!System.IO.File.Exists(Application.persistentDataPath + "/save_stats.db")) {
            saveSystem.CreateNew();
        }
    }

    private void LoadSave(SaveSystem saveSystem) {
        SaveStats saveStats = saveSystem.Load();
        SceneManager.LoadScene(saveStats.SceneName);
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = new Vector3(saveStats.Player.X, saveStats.Player.Y, saveStats.Player.Z);
        LevelSystem.Level = saveStats.Level;
    }
}