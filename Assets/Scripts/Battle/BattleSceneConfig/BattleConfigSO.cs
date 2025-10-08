using UnityEngine;

[CreateAssetMenu(menuName = "BattleConfig")]
public class BattleConfigSO : ScriptableObject {
    public StatusCharacters EnemyStatus;
    public GameObject Background;
    public Sprite EnemySprite;
    public RuntimeAnimatorController EnemyAnimatorController;
    public Vector3 EnemyPosition;
    public int Index;
}