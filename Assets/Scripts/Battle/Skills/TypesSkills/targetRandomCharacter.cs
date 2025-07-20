using UnityEngine;

public class targetRandomCharacter : TypeSkill
{
    private CharacterAttributes[] characterStatus = new CharacterAttributes[1];
    
    public override CharacterAttributes[] targets(){
        characterStatus[0] = Characters()[RandomTarget()].GetComponent<CharacterAttributes>();
        return characterStatus;
    }

    private int RandomTarget() {
        return Random.Range(0, Characters().Length);
    }

    private GameObject[] Characters() {
        return GameObject.FindGameObjectsWithTag("Character");
    }
}
