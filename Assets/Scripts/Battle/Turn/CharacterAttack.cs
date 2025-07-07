using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    [SerializeField] GameObject CaixaTurnAttack;
    
    public void ClickCharacter(CharacterStatus Character){
        if (!Character.attackInTheTurn) {
            CaixaTurnAttack.SetActive(true);
            PlayerCharactersSkills.character = Character;
        }
    }
}
