using System.Collections.Generic;
using UnityEngine;

public class CharacterClick : MonoBehaviour {
    static public ICharacterInteraction CharacterInteraction = new CharacterAttack();
    static public CharacterAttributes CharacterAttr;
    static public List<CharacterAttributes> CharactersSelect = new List<CharacterAttributes>();

    public void ClickCharacter(CharacterAttributes character) {
        CharacterInteraction.Interaction(character);
    }
}