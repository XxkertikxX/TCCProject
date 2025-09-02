public class CharacterSelect : ICharacterInteraction {
    public void Interaction(CharacterAttributes character) {
        CharacterClick.CharactersSelect.Add(character);
    }
}