using UnityEngine;

public class RandomUpgrade
{
    static public void RandomUpgradeSelect(GameObject upgrade) {
		int randomNumber = Random.Range(0, 100);
		
		if(randomNumber < 5) {
			upgrade.AddComponent<UpgradeMana>();
			return;
		}
		if(randomNumber < 28) {
			upgrade.AddComponent<UpgradeLife>();
			return;
		}
		if(randomNumber < 50) {
			upgrade.AddComponent<UpgradeRhythm>();
			return;
		}
		if(randomNumber < 56) {
			upgrade.AddComponent<UpgradeReductionMana>();
			return;
		}
		if(randomNumber < 75) {
			upgrade.AddComponent<UpgradeDefense>();
			return;
		}
		if(randomNumber <= 100) {
			upgrade.AddComponent<UpgradePower>();
			return;
		}
	}
}
