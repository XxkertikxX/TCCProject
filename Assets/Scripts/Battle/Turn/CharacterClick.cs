using System.Collections.Generic;
using UnityEngine;

public class CharacterClick : MonoBehaviour {
    static public ICharacterInteraction CharacterInteraction = new CharacterAttack();
    static public CharacterAttributes CharacterAttr;
    static public List<CharacterAttributes> CharactersSelect = new List<CharacterAttributes>();

    [SerializeField] private Event eventDialog;

    public void ClickCharacter(CharacterAttributes character) {
        CharacterInteraction.Interaction(character);

        if(CharacterInteraction == new CharacterAttack()) {
            eventDialog.EventInvoke();
        }
    }
}