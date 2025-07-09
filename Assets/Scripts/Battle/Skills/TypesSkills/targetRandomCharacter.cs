using UnityEngine;

public class targetRandomCharacter : TypeSkill
{
    private CharacterStatus[] characterStatus = new CharacterStatus[1];
    
    public override CharacterStatus[] targets(){
        characterStatus[0] = characters()[randomTarget()].GetComponent<CharacterStatus>();
        return characterStatus;
    }

    private int randomTarget() {
        return Random.Range(0, characters().Length);
    }

    private GameObject[] characters() {
        return GameObject.FindGameObjectsWithTag("Character");
    }
}
