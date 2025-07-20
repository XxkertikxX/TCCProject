using UnityEngine;

public class targetRandomCharacter : TypeSkill
{
    private CharacterAtributes[] characterStatus = new CharacterAtributes[1];
    
    public override CharacterAtributes[] targets(){
        characterStatus[0] = Characters()[RandomTarget()].GetComponent<CharacterAtributes>();
        return characterStatus;
    }

    private int RandomTarget() {
        return Random.Range(0, Characters().Length);
    }

    private GameObject[] Characters() {
        return GameObject.FindGameObjectsWithTag("Character");
    }
}
