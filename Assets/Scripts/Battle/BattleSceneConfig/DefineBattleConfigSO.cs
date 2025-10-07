using UnityEngine;

public class DefineBattleConfigSO : MonoBehaviour
{    
    [SerializeField] private BattleConfigSO defaultSO;
    [SerializeField] private BattleConfigSO newSO;

    public void DefineSO() {
        defaultSO.EnemyStatus = newSO.EnemyStatus;
        defaultSO.Background = newSO.Background;
        defaultSO.EnemySprite = newSO.EnemySprite;
        defaultSO.EnemyAnimatorController = newSO.EnemyAnimatorController;
        defaultSO.EnemyPosition = newSO.EnemyPosition;
    }
}