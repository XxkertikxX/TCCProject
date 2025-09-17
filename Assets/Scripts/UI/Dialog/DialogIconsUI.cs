using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(IDialogWriter))]
public class DialogIconsUI : MonoBehaviour
{
	private IDialogWriter dialogWriter;

	[SerializeField] private IconsSO icons;

	[SerializeField] private Image imageCharacter;
	[SerializeField] private Text textName;

	void Start() {
		dialogWriter = GetComponent<IDialogWriter>();
	}
	
    void OnEnable() {
		dialogWriter.OnPassLine += ApplyIcons;
	}
	
	void OnDisable() {
		dialogWriter.OnPassLine -= ApplyIcons;
	}
	
	private void ApplyIcons(int index) {
		imageCharacter.sprite = icons.IconsCharacter[index].ImageCharacter;
		textName.text = icons.IconsCharacter[index].NameCharacter;
	}
}
