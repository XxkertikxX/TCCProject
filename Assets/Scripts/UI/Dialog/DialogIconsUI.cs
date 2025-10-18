using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(IDialogWriter))]
public class DialogIconsUI : MonoBehaviour
{
	public event Action<string> OnApplyIcons;
	
	private IDialogWriter dialogWriter;

	[SerializeField] private IconsSO icons;

	[SerializeField] private Image imageCharacter;
	[SerializeField] private Text textName;

	void Awake() {
		dialogWriter = GetComponent<IDialogWriter>();
	}
	
    void OnEnable() {
		var battleIcons = GameObject.FindObjectOfType<BattleApplyConfig>().battleConfigSO.Icons;
		if(battleIcons != null) {
			icons = battleIcons;
		}
		dialogWriter.OnPassLine += ApplyIcons;
	}
	
	void OnDisable() {
		dialogWriter.OnPassLine -= ApplyIcons;
	}
	
	private void ApplyIcons(int index) {
		string nameCharacter = icons.IconsCharacter[index].NameCharacter;
		imageCharacter.sprite = icons.IconsCharacter[index].ImageCharacter;
		textName.text = nameCharacter;
		OnApplyIcons?.Invoke(nameCharacter);
	}
}
