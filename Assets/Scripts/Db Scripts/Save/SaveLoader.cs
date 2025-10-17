using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

[RequireComponent(typeof(DontDestroyOnLoad))]
public class SaveLoader : MonoBehaviour
{
    public void Load() {
        SaveSystem saveSystem = new SaveSystem();
        StartCoroutine(LoadSave(saveSystem));
    }

    private IEnumerator LoadSave(SaveSystem saveSystem) {
        SaveStats saveStats = saveSystem.OpenLoad();
        if(saveStats.SceneName == SceneManager.GetActiveScene().name) {
            yield return SceneManager.LoadSceneAsync(saveStats.SceneName, LoadSceneMode.Single);
		    yield return Resources.UnloadUnusedAssets();
		    GC.Collect();
        }

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = new Vector3(saveStats.Player.X, saveStats.Player.Y, saveStats.Player.Z);
        LevelSystem.Level = saveStats.Level;
    }
}