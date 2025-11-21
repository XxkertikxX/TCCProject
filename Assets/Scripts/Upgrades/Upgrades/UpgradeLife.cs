using UnityEngine;

[CreateAssetMenu(menuName = "LifeCreator")]
public class UpgradeLife : UpgradeSO {
    public override void Upgrade(StatusCharacters status) {
        status.Life += Value;
    }
}
