using UnityEngine;

public class BatAttackAlert : MonoBehaviour
{
    void OnEnable() {
        BatAttackSystem.OnBatAttack += ShowAlert;
        BatAttackSystem.OnBatEndAttack += RemoveAlert;
        BatAttackSystem.OnBatInPlayer += RemoveAlert;
    }

    void OnDisable() {
        BatAttackSystem.OnBatAttack -= ShowAlert;
        BatAttackSystem.OnBatEndAttack -= RemoveAlert;
        BatAttackSystem.OnBatInPlayer -= RemoveAlert;
    }

    private void ShowAlert() {
        gameObject.SetActive(false);
    }

    private void RemoveAlert() {
        gameObject.SetActive(false);
    }
}
