using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    [SerializeField] private GameObject caixaTurnAttack;
    
    public void ClickCharacter(CharacterAttributes character){
        if (!character.AttackInTheTurn) {
            caixaTurnAttack.SetActive(true);
            PlayerCharactersSkills.Character = character;
        }
    }
}
