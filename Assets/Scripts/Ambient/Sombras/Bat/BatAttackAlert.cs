using UnityEngine;

public class BatAttackAlert : MonoBehaviour
{
    [SerializeField] private GameObject alert;

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
        alert.SetActive(false);
    }

    private void RemoveAlert() {
        alert.SetActive(false);
    }
}
