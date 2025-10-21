using UnityEngine;

public class UpgradePower : MonoBehaviour, UpgradeBase {
    public void Upgrade(StatusCharacters status, float value) {
        status.Power += value;
    }
}
