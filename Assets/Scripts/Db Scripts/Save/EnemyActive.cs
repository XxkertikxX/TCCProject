using UnityEngine;
using LiteDB;

public class EnemyActive : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private int index;

    void Awake() { 
        SaveSystem saveSystem = new SaveSystem();
        SaveStats saveStats = saveSystem.OpenLoad();
        enemy.SetActive(!saveStats.DefeatEnemy[index]);
        Debug.Log(saveStats.DefeatEnemy[index]);
    }
}