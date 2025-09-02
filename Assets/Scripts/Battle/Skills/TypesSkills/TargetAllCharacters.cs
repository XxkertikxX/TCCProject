using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "TargetAllCharacters")]
public class TargetAllCharacters : TypeSkill
{
    public override IEnumerator Targets() {
        CharactersAttributes = GetAllAttributes();
        yield return null;
    }

    private List<CharacterAttributes> GetAllAttributes() {
        List<CharacterAttributes> list = new List<CharacterAttributes>();
        GameObject[] chars = GameObject.FindGameObjectsWithTag("Character");
        foreach (GameObject character in chars) {
            list.Add(character.GetComponent<CharacterAttributes>());
        }
        return list;
    }
}