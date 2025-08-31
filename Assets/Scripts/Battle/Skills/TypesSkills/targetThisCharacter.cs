using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "TargetThisCharacter")]
public class TargetThisCharacter : TypeSkill
{
    public GameObject ThisCharacter;
    public string FallbackName;
    public int FallbackIndex;

    public override IEnumerator Targets() {
        CharactersAttributes = BuildListFrom(GetTarget());
        yield return null;
    }

    public void SetThisCharacter(GameObject go)  {
        ThisCharacter = go; 
    }

    public void ClearThisCharacter()  {
        ThisCharacter = null; 
    }

    private GameObject[] GetAllChars() => GameObject.FindGameObjectsWithTag("Character");

    private GameObject GetTarget() {
        if (ThisCharacter != null) return ThisCharacter;
        var chars = GetAllChars();
        if (!string.IsNullOrEmpty(FallbackName)) {
            for (int i = 0; i < chars.Length; i++)
                if (chars[i].name == FallbackName) return chars[i];
        }
        if (chars.Length == 0) return null;
        return chars[Mathf.Clamp(FallbackIndex, 0, chars.Length - 1)];
    }

    private List<CharacterAttributes> BuildListFrom(GameObject go) {
        List<CharacterAttributes> list = new List<CharacterAttributes>();
        if (go == null) return list;
        var a = go.GetComponent<CharacterAttributes>();
        if (a != null) list.Add(a);
        return list;
    }
}