using UnityEngine;

public class UpgradeLife : UpgradeBase {
    public override void Upgrade(StatusCharacters status, float value) {
        status.Life += value;
    }
}
