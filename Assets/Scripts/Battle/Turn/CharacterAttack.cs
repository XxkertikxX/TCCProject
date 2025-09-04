using System;

public class CharacterAttack : ICharacterInteraction
{
    static public event Action OnCharacterPreparedAttack;

    public void Interaction(CharacterAttributes character){
        if (character.TurnsForCanAttack == 0) {
            OnCharacterPreparedAttack?.Invoke();
            CharacterClick.CharacterAttr = character;
        }
    }
}