using UnityEngine;

public class UpgradePower : UpgradeBase {
    public override void Upgrade(StatusCharacters status, float value) {
        status.Power += value;
    }
	
	public override void UpgradeDetails(StatusCharacters status, float value) {
		
	}
}
