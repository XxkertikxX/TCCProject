using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    [SerializeField] GameObject CaixaTurnAttack;
    
    public void ClickCharacter(StatusCharacters Character){
        if (!Character.AttackInTheTurn) {
            CaixaTurnAttack.SetActive(true);
            CaixaTurnAttack.GetComponent<PlayerCharactersSkills>().skills = Character.skills;
        }
    }
}
