using System;

public class CharacterAttack : ICharacterInteraction
{
    static public event Action OnCharacterPreparedAttack;

    public void Interaction(CharacterAttributes character){
        if (character.TurnsForCanAttack == 0) {
			CharacterClick.CharacterAttr = character;
            OnCharacterPreparedAttack?.Invoke();
        }
    }
}