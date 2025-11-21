using UnityEngine;

public class RandomUpgrade : MonoBehaviour
{
	[SerializeField] private UpgradeSO[] upgrades;
	
	public UpgradeSO RandomUpgradeSelect() {
		int randomNumber = Random.Range(0, 100);

		UpgradeSO selected;

		if (randomNumber < 5) selected = upgrades[0];
		else if (randomNumber < 28) selected = upgrades[1];
		else if (randomNumber < 50) selected = upgrades[2];
		else if (randomNumber < 56) selected = upgrades[3];
		else if (randomNumber < 75) selected = upgrades[4];
		else selected = upgrades[5];

		return Instantiate(selected);
	}
}
