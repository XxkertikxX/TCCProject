using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "TargetRandom")]
public class targetRandomCharacter : TypeSkill
{
    private List<CharacterAttributes> characterStatus = new List<CharacterAttributes>();
    
    public override List<CharacterAttributes> Targets(){
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
