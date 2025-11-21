using UnityEngine;
using UnityEngine.UI;

public class ChoiceUpgrade : MonoBehaviour
{
	private UpgradeSO upgrade;
	
	[SerializeField] private RandomUpgrade randomUpgrade;
	
	[SerializeField] private Text textTitle;
	[SerializeField] private Text textDescription;
	[SerializeField] private SpriteRenderer icon;
	
    void OnEnable() {
		upgrade = randomUpgrade.RandomUpgradeSelect();
		ApplyChoice();
	}
	
	private void ApplyChoice() {
		textTitle.text = upgrade.Name;
		textDescription.text = upgrade.Description;
		icon.sprite = upgrade.Icon;
	}
}
