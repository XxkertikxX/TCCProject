using UnityEngine;

public class BattleApplyConfig : MonoBehaviour {
    [SerializeField] private BattleConfigSO battleConfigSO;

    [SerializeField] private SpriteRenderer enemySpriteRenderer;
    [SerializeField] private CharacterAttributes enemyCharacter;
    [SerializeField] private Animator animEnemy;
    [SerializeField] private Transform enemyTransform;

    void Awake() {
        Instantiate(battleConfigSO.Background);
        enemySpriteRenderer.sprite = battleConfigSO.EnemySprite;
        enemyCharacter.Character = battleConfigSO.EnemyStatus;
        animEnemy.runtimeAnimatorController = battleConfigSO.EnemyAnimatorController;
        enemyTransform.position = battleConfigSO.EnemyPosition;
    }
}
