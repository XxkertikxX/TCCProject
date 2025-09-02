using System.Collections.Generic;

public class CharacterSelect : ICharacterInteraction {
    public void Interaction(CharacterAttributes character) {
        CharacterClick.CharactersSelect = new List<CharacterAttributes>();
        CharacterClick.CharactersSelect.Add(character);
    }
}