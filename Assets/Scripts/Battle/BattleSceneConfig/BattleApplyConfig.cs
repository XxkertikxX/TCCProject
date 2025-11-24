using UnityEngine;
using UnityEngine.UI;

public class BattleApplyConfig : MonoBehaviour {
    [SerializeField] public BattleConfigSO battleConfigSO;

    [SerializeField] private SpriteRenderer enemySpriteRenderer;
    [SerializeField] private Image LifeBar;
    [SerializeField] private CharacterAttributes enemyCharacter;
    [SerializeField] private Animator animEnemy;
    [SerializeField] private Transform enemyTransform;
    [SerializeField] private EnemyTurn enemyTurn;
    [SerializeField] private DialogIconsUI iconsUI;
    [SerializeField] private GameObject dialog;

    void Awake() {
        Instantiate(battleConfigSO.Background);
        enemySpriteRenderer.sprite = battleConfigSO.EnemySprite;
        LifeBar.sprite = battleConfigSO.LifeBarSprite;
        enemyCharacter.Character = battleConfigSO.EnemyStatus;
        animEnemy.runtimeAnimatorController = battleConfigSO.EnemyAnimatorController;
        enemyTransform.position = battleConfigSO.EnemyPosition;
        enemyTurn.Index = battleConfigSO.Index;
        dialog.SetActive(battleConfigSO.hasDialog);
    }
}
