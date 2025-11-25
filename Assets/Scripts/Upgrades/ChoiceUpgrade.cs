using UnityEngine;
using UnityEngine.UI;

public class ChoiceUpgrade : MonoBehaviour
{
	static public bool Choice;
	private UpgradeSO upgrade;
	
	[SerializeField] private RandomUpgrade randomUpgrade;
	
	[SerializeField] private Text textTitle;
	[SerializeField] private Text textDescription;
	[SerializeField] private Image icon;
	
	public void PressButton() {
		upgrade.Upgrade(LevelUp.CharacterForUp);
		Choice = true;
	}
	
    void OnEnable() {
        UpgradeSO original = randomUpgrade.PickOriginal(LevelUp.upgradesUsados);
        LevelUp.upgradesUsados.Add(original);
        upgrade = Instantiate(original);
        ApplyChoice();
	}
	
	private void ApplyChoice() {
		textTitle.text = upgrade.Name;
		textDescription.text = upgrade.Description;
		icon.sprite = upgrade.Icon;
	}
}
