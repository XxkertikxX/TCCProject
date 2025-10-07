using UnityEngine;

public class BattleApplyConfig : MonoBehaviour {
    [SerializeField] private BattleConfigSO battleConfigSO;

    [SerializeField] private GameObject background;
    [SerializeField] private SpriteRenderer enemySpriteRenderer;
    [SerializeField] private CharacterAttributes enemyCharacter;
    [SerializeField] private Animator animEnemy;

    void Awake() {
        background = battleConfigSO.Background;
        enemySpriteRenderer.sprite = battleConfigSO.EnemySprite;
        enemyCharacter.Character = battleConfigSO.EnemyStatus;
        animEnemy.runtimeAnimatorController = battleConfigSO.EnemyAnimatorController;
    }
}
