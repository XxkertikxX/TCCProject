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
        defaultSO.Index = newSO.Index;
		defaultSO.Text = newSO.Text;
		defaultSO.Icons = newSO.Icons;
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            DefineSO();
        }
    }
}