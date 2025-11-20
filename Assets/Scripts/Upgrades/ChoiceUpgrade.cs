using UnityEngine;

public class ChoiceUpgrade : MonoBehaviour
{
    void OnEnable() {
		RandomUpgrade.RandomUpgradeSelect(gameObject);
	}
	
	void OnDisable() {
		gameObject.RemoveComponent<UpgradeBase>();
	}
}
