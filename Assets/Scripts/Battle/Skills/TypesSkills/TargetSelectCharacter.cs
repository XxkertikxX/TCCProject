using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "TargetSelectCharacter")]
public class TargetSelectCharacter : TypeSkill
{
    public GameObject SelectedCharacter;
    public int SelectedIndex;

    public override IEnumerator Targets()
    {
        CharactersAttributes = BuildListFrom(GetSelected());
        yield return null;
    }

    public void SetSelectedCharacter(GameObject go) 
    {
        SelectedCharacter = go; 
    }
    public void SetSelectedIndex(int i) 
    {
        SelectedIndex = i; 
    }
    public void ClearSelected() 
    {
        SelectedCharacter = null; 
    }

    private GameObject[] GetAllChars() => GameObject.FindGameObjectsWithTag("Character");

    private GameObject GetSelected()
    {
        if (SelectedCharacter != null) return SelectedCharacter;
        var chars = GetAllChars();
        if (chars.Length == 0) return null;
        return chars[Mathf.Clamp(SelectedIndex, 0, chars.Length - 1)];
    }

    private List<CharacterAttributes> BuildListFrom(GameObject go)
    {
        var list = new List<CharacterAttributes>();
        if (go == null) return list;
        var a = go.GetComponent<CharacterAttributes>();
        if (a != null) list.Add(a);
        return list;
    }
}