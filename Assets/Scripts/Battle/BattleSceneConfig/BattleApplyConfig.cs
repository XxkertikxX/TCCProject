using UnityEngine;

public class BattleApplyConfig : MonoBehaviour {
    [SerializeField] private BattleConfigSO battleConfigSO;

    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject background;

    void Awake() {
        enemy = battleConfigSO.Enemy;
        background = battleConfigSO.Background;
    }
}
