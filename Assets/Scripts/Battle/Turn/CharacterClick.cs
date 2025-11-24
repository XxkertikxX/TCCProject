using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterClick : MonoBehaviour
{	
    static public ICharacterInteraction CharacterInteraction = new CharacterAttack();
    static public CharacterAttributes CharacterAttr;
    static public List<CharacterAttributes> CharactersSelect = new List<CharacterAttributes>();

    [SerializeField] private Event select;
	static private Event SelectStatic;
	
	void Awake() {
		SelectStatic = select;
	}
	
    public void ClickCharacter(CharacterAttributes character) {
		if(EnemyTurn.Finish) return;
        CharacterInteraction.Interaction(character);
    }
	
	static public void SelectInvokeEvent() {
		SelectStatic.EventInvoke();
	}
}
