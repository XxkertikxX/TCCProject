using UnityEngine;

public class targetRandomCharacter : TypeSkill
{
    private CharacterStatus[] characterStatus = new CharacterStatus[1];
    
    public override CharacterStatus[] targets(){
        characterStatus[0] = Characters()[RandomTarget()].GetComponent<CharacterStatus>();
        return characterStatus;
    }

    private int RandomTarget() {
        return Random.Range(0, Characters().Length);
    }

    private GameObject[] Characters() {
        return GameObject.FindGameObjectsWithTag("Character");
    }
}
