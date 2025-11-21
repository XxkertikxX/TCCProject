using UnityEngine;

[CreateAssetMenu(menuName = "ReductionManaCreator")]
public class UpgradeReductionMana : UpgradeSO {
    public override void Upgrade(StatusCharacters status) {
        foreach(var skill in status.Skills) {
			skill.ManaConsume -= Value;
		}
    }
}
