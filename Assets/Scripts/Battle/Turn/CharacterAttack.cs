using UnityEngine;
using System;

public class CharacterAttack : ICharacterInteraction
{
    static public ICharacterInteraction CharacterInteraction;
    static public event Action OnCharacterPreparedAttack;

    public void Interaction(CharacterAttributes character){
        if (!character.AttackInTheTurn) {
            OnCharacterPreparedAttack?.Invoke();
            CharacterClick.CharacterAttr = character;
        }
    }
}