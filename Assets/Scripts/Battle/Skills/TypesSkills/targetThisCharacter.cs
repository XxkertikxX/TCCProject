using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "TargetThisCharacter")]
public class TargetThisCharacter : TypeSkill
{
    public override IEnumerator Targets() {
        CharactersAttributes = new List<CharacterAttributes>();
        CharactersAttributes.Add(CharacterClick.CharacterAttr);
        yield return null;
    }
}