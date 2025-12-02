using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class applyiconcharacter : MonoBehaviour
{
	[SerializeField] private CharacterAttributes enemy;
	[SerializeField] private Text name;
	[SerializeField] private BattleApplyConfig config;
	
	void Update() {
		if(!config.battleConfigSO.hasDialog) {
			if (CharacterClick.CharacterAttr != null) {
				Icons();
			}
			else {
				gameObject.GetComponent<Image>().enabled = false;
				name.text = enemy.Character.Name;
			}
		}
	}

	private void Icons() {
		gameObject.GetComponent<Image>().enabled = (CharacterClick.CharacterAttr.Character.Icon != null);
		GetComponent<Image>().sprite = CharacterClick.CharacterAttr.Character.Icon;
		name.text = CharacterClick.CharacterAttr.Character.Name;
	}

}