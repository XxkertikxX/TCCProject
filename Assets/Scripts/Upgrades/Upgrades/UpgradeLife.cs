using UnityEngine;

public class UpgradeLife : MonoBehaviour, UpgradeBase {
    public void Upgrade(StatusCharacters status, float value) {
        status.Life += value;
    }
	
	public void UpgradeDetails(StatusCharacters status, float value) {
		
	}
}
