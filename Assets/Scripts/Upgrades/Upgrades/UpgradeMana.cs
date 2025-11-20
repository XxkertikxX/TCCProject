using UnityEngine;

public class UpgradeMana : UpgradeBase {
    [SerializeField] private ManaSO manaSO;

    public override void Upgrade(StatusCharacters status, float value) {
        manaSO.Mana += value;
    }
	
	public override void UpgradeDetails(StatusCharacters status, float value) {
		
	}
}
