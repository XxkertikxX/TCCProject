using System.Collections.Generic;
using UnityEngine;

public class Turns : MonoBehaviour
{
    List<StatusCharacters> statusCharacters;
    Queue<ISkill> characters;

    private void OnEnable() {
        TakeCharacters();
    }

    void TakeCharacters() {
        GameObject[] Char = GameObject.FindGameObjectsWithTag("Character");
        foreach (var c in Char) {
            statusCharacters.Add(c.GetComponent<StatusCharacters>());
        }
    }

    void OrderAttack()
    {
        List<StatusCharacters> statsChar;

        for (int i = 0; i < characters.Count; i++)
        {
        }
    }
}
