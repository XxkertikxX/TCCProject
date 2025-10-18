using UnityEngine;

public class BattleApplyConfig : MonoBehaviour {
    [SerializeField] public BattleConfigSO battleConfigSO;

    [SerializeField] private SpriteRenderer enemySpriteRenderer;
    [SerializeField] private CharacterAttributes enemyCharacter;
    [SerializeField] private Animator animEnemy;
    [SerializeField] private Transform enemyTransform;
    [SerializeField] private EnemyTurn enemyTurn;
    [SerializeField] private IconsSO icons;

    void Awake() {
        Instantiate(battleConfigSO.Background);
        enemySpriteRenderer.sprite = battleConfigSO.EnemySprite;
        enemyCharacter.Character = battleConfigSO.EnemyStatus;
        animEnemy.runtimeAnimatorController = battleConfigSO.EnemyAnimatorController;
        enemyTransform.position = battleConfigSO.EnemyPosition;
        enemyTurn.Index = battleConfigSO.Index;
        if(battleConfigSO.Icons != null)
            icons = battleConfigSO.Icons;
    }
}
