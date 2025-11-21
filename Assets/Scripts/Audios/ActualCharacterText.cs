using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActualCharacterText : MonoBehaviour
{
    [SerializeField] private Text name;
	
	void Update() {
		if(CharacterClick.CharacterAttr != null) {
			name.text = CharacterClick.CharacterAttr.Character.Name;
		}
	}
} 
