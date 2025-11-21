using UnityEngine;

[CreateAssetMenu(menuName = "PowerCreator")]
public class UpgradePower : UpgradeSO {
    public override void Upgrade(StatusCharacters status) {
        status.Power += Value;
    }
}
