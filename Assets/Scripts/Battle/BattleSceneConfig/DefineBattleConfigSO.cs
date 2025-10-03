using UnityEngine;

public class DefineBattleConfigSO : MonoBehaviour
{    
    [SerializeField] private BattleConfigSO defaultSO;
    [SerializeField] private BattleConfigSO newSO;

    public void DefineSO() {
        defaultSO = newSO;
    }
}
