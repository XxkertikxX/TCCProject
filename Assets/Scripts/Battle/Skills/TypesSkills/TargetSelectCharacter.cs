using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "TargetSelectCharacter")]
public class TargetSelectCharacter : TypeSkill
{
    public override IEnumerator Targets() {
        ChangeCharacterInteraction();
        List<CharacterAttributes> Characters = CharacterClick.CharactersSelect;
        Characters = new List<CharacterAttributes>();
        yield return new WaitUntil(() => Characters.Count >= 1);
        CharactersAttributes = Characters;
        ResetCharacterInteraction();
    }

    private void ChangeCharacterInteraction() {
        CharacterClick.CharacterInteraction = new CharacterSelect();
    }

    private void ResetCharacterInteraction() {
        CharacterClick.CharacterInteraction = new CharacterAttack();
    }
}