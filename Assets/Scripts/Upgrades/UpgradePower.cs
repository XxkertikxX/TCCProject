using UnityEngine;

public class UpgradePower : MonoBehaviour, UpgradeBase {
    public void Upgrade(StatusCharacters status, float value) {
        status.Power += value;
    }
	
	public void UpgradeDetails(StatusCharacters status, float value) {
		
	}
}
