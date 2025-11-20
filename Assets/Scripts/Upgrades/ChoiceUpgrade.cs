using UnityEngine;

public class ChoiceUpgrade : MonoBehaviour
{
	private UpgradeBase upgrade;
	
    void OnEnable() {
		upgrade = RandomUpgrade.RandomUpgradeSelect(gameObject);
	}
	
	void OnDisable() {
		Destroy(upgrade);
	}
}
