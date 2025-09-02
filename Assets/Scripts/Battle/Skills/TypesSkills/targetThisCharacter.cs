using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "TargetThisCharacter")]
public class TargetThisCharacter : TypeSkill
{
    public override IEnumerator Targets() {
        CharactersAttributes = new List<CharacterAttributes>();
        //CharacterAttributes.Add(PlayerCharactersSkills.CharacterAttr);
        yield return null;
    }
}