using UnityEngine;

[CreateAssetMenu(menuName = "DefenseCreator")]
public class UpgradeDefense : UpgradeSO {
    public override void Upgrade(StatusCharacters status) {
        status.Defense += Value;
    }
}
