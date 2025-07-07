using UnityEngine;

public class targetRandomCharacter : TypeSkill
{
    private CharacterStatus[] characterStatus = new CharacterStatus[1];
    
    public override CharacterStatus[] targets(){
        characterStatus[0] = characters()[randomTarget()].GetComponent<CharacterStatus>();
        return characterStatus;
    }

    int randomTarget() {
        return Random.Range(0, characters().Length);
    }

    GameObject[] characters() {
        return GameObject.FindGameObjectsWithTag("Character");
    }
}
