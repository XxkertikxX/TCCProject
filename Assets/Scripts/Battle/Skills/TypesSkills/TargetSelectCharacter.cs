using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "TargetSelectCharacter")]
public class TargetSelectCharacter : TypeSkill
{
    public override IEnumerator Targets() {
        ChangeCharacterInteraction();
        CharacterClick.CharactersSelect = new List<CharacterAttributes>();
        yield return new WaitUntil(() => CharacterClick.CharactersSelect.Count == 1);
        CharactersAttributes = CharacterClick.CharactersSelect;;
        ResetCharacterInteraction();
    }

    private void ChangeCharacterInteraction() {
        CharacterClick.CharacterInteraction = new CharacterSelect();
    }

    private void ResetCharacterInteraction() {
        CharacterClick.CharacterInteraction = new CharacterAttack();
    }
}