using UnityEngine;
using UnityEngine.UI;

public class CharacterUpgrade : MonoBehaviour
{
	[SerializeField] private SpriteRenderer icon;
	
	[SerializeField] private Text name;
	[SerializeField] private Text level;
	[SerializeField] private Text xp;
	[SerializeField] private Text hp;
	[SerializeField] private Text defense;
	[SerializeField] private Text power;
	
    void Update() {
		icon.sprite = Character().Icon;
		name.text = Character().Name;
		level.text = Character().Level.ToString();
		xp.text = Character().Xp.ToString();
		hp.text = Character().Life.ToString();
		defense.text = Character().Defense.ToString();
		power.text = Character().Power.ToString();
	}
	
	private StatusCharacters Character() {
		return LevelUp.CharacterForUp;
	}
}
