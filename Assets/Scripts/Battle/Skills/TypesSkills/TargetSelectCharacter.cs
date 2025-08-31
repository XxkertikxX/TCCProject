using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "TargetSelectCharacter")]
public class TargetSelectCharacter : TypeSkill
{
    public GameObject SelectedCharacter;
    public int SelectedIndex;
    public float SelectionTimeout = -1f;

    public bool IsSelecting { get; private set; }
    public bool IsConfirmed { get; private set; }

    public override IEnumerator Targets()
    {
        IsSelecting = true;
        IsConfirmed = false;
        float t = 0f;
        while (!IsConfirmed)
        {
            if (SelectionTimeout > 0f)
            {
                t += Time.deltaTime;
                if (t >= SelectionTimeout) break;
            }
            yield return null;
        }
        IsSelecting = false;
        CharactersAttributes = BuildListFrom(GetSelected());
        ClearSelected();
        yield return null;
    }

    public void SetSelectedCharacter(GameObject go) { SelectedCharacter = go; }
    public void SetSelectedIndex(int i) { SelectedIndex = i; }
    public void ConfirmSelection() { IsConfirmed = true; }
    public void CancelSelection() { IsConfirmed = false; IsSelecting = false; ClearSelected(); }
    public void ClearSelected() { SelectedCharacter = null; SelectedIndex = 0; }

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