using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "TargetRandom")]
public class targetRandomCharacter : TypeSkill
{    
    public override List<CharacterAttributes> Targets() {
        List<CharacterAttributes> characterStatus = new List<CharacterAttributes>();
        characterStatus.Add(Characters()[RandomTarget()].GetComponent<CharacterAttributes>());
        return characterStatus;
    }

    private int RandomTarget() {
        return Random.Range(0, Characters().Length);
    }

    private GameObject[] Characters() {
        return GameObject.FindGameObjectsWithTag("Character");
    }
}
