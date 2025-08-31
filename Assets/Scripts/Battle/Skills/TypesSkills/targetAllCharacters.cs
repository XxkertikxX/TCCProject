using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "TargetAllCharacters")]
public class TargetAllCharacters : TypeSkill
{
    public override IEnumerator Targets()
    {
        CharactersAttributes = GetAllAttributes();
        yield return null;
    }

    private List<CharacterAttributes> GetAllAttributes()
    {
        var list = new List<CharacterAttributes>();
        var chars = GameObject.FindGameObjectsWithTag("Character");
        for (int i = 0; i < chars.Length; i++)
        {
            var a = chars[i].GetComponent<CharacterAttributes>();
            if (a != null) list.Add(a);
        }
        return list;
    }
}