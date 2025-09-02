using System.Collections.Generic;
using UnityEngine;

public class CharacterClick : MonoBehaviour {
    static public ICharacterInteraction CharacterInteraction;
    static public CharacterAttributes CharacterAttr;
    static public List<CharacterAttributes> CharactersSelect;

    public void ClickCharacter(CharacterAttributes character) {
        CharacterInteraction.Interaction(character);
    }
}