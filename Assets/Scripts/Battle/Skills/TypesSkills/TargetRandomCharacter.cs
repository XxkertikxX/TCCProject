using UnityEngine;
using System.Collections.Generic;
using System.Collections;

[CreateAssetMenu(menuName = "TargetRandom")]
public class TargetRandomCharacter : TypeSkill
{    
    public override IEnumerator Targets() {
        List<CharacterAttributes> characterStatus = new List<CharacterAttributes>();
        characterStatus.Add(Characters()[RandomTarget()].GetComponent<CharacterAttributes>());
        CharactersAttributes = characterStatus;
        yield return null;
    }

    private int RandomTarget() {
        return Random.Range(0, Characters().Length);
    }

    private GameObject[] Characters() {
        return GameObject.FindGameObjectsWithTag("Character");
    }
}