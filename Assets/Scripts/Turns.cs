using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Turns : MonoBehaviour
{
    List<StatusCharacters> statusCharacters;
    Queue<ISkill> characters;

    private void OnEnable() {
        TakeCharacters();
        OrderAttack();
    }

    void TakeCharacters() {
        GameObject[] Char = GameObject.FindGameObjectsWithTag("Character");
        foreach (var c in Char) {
            statusCharacters.Add(c.GetComponent<StatusCharacters>());
        }
    }

    void OrderAttack() {
        statusCharacters = statusCharacters.OrderByDescending(stats => stats.speedAttack).ToList();
    }
}
