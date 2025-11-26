using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class applyiconcharacter : MonoBehaviour
{
	[SerializeField] private Text name;
	void OnEnable()	{
		if (CharacterClick.CharacterAttr != null) {
			StartCoroutine(Icons());
		}
	}

	private IEnumerator Icons() {
		yield return null;
		gameObject.GetComponent<Image>().enabled = (CharacterClick.CharacterAttr.Character.Icon != null);
		GetComponent<Image>().sprite = CharacterClick.CharacterAttr.Character.Icon;
		name.text = CharacterClick.CharacterAttr.Character.Name;
	}

}
