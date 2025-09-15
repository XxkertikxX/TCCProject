using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoader : MonoBehaviour
{
    private void LoadSave(SaveSystem saveSystem) {
        SaveStats saveStats = saveSystem.Load();
        SceneManager.LoadScene(saveStats.SceneName);
        //GameObject player = GameObject.FindGameObjectWithTag("Player");
        //player.transform.position = new Vector3(saveStats.Player.X, saveStats.Player.Y, saveStats.Player.Z);
        LevelSystem.Level = saveStats.Level;
    }
}