using UnityEngine;

public class UpgradePower : UpgradeBase {
    public override void Upgrade(StatusCharacters status, float value) {
        status.Power += value;
    }
}
