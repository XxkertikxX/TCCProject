using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpExternalEnemy : MonoBehaviour
{
    [SerializeField] private LevelUp[] charactersLevel;
    static private LevelUp[] charactersLevelClone;

    private void Awake() {
        charactersLevelClone = charactersLevel;
    }

    static public IEnumerator LevelUp(int index) {
        foreach (var character in charactersLevelClone) {
            yield return character.UpLevel();
        }
        Save(index, true);
    }



   static private void Save(int index, bool win) {
        SaveSystem saveSystem = new SaveSystem();
        saveSystem.SaveBattle(index, win);
        GameObject.FindObjectOfType<SaveLoader>().Load();
    }
}
