using UnityEngine;

public class RandomUpgrade
{
    static public UpgradeBase RandomUpgradeSelect(GameObject upgrade) {
		int randomNumber = Random.Range(0, 100);
		
		if(randomNumber < 5) {
			upgrade.AddComponent<UpgradeMana>();
			return new UpgradeMana();
		}
		if(randomNumber < 28) {
			upgrade.AddComponent<UpgradeLife>();
			return new UpgradeLife();
		}
		if(randomNumber < 50) {
			upgrade.AddComponent<UpgradeRhythm>();
			return new UpgradeRhythm();
		}
		if(randomNumber < 56) {
			upgrade.AddComponent<UpgradeReductionMana>();
			return new UpgradeReductionMana();
		}
		if(randomNumber < 75) {
			upgrade.AddComponent<UpgradeDefense>();
			return new UpgradeDefense();
		}
		if(randomNumber <= 100) {
			upgrade.AddComponent<UpgradePower>();
			return new UpgradePower();
		}
		return null;
	}
}
