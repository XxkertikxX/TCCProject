using UnityEngine;

public class EnemyActive : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private int index;
    [SerializeField] private CinematicPlayed ifWasDefeated;

    void Awake() { 
        SaveSystem saveSystem = new SaveSystem();
        SaveStats saveStats = saveSystem.OpenLoad();
        enemy.SetActive(!saveStats.DefeatEnemy[index]);
        ifWasDefeated.WasPlayed = saveStats.DefeatEnemy[index];
    }
}
