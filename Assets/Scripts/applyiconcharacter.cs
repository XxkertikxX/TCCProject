using UnityEngine;
using UnityEngine.UI;

public class applyiconcharacter : MonoBehaviour
{
	[SerializeField] private Text name;
    void OnEnable() {
		if(CharacterClick.CharacterAttr != null) {
			GetComponent<Image>().sprite = CharacterClick.CharacterAttr.Character.Icon;
			name.text = CharacterClick.CharacterAttr.Character.Name;
		}
    }
}
