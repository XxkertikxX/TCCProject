using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    [SerializeField] private GameObject caixaTurnAttack;
    
    public void ClickCharacter(CharacterAtributes character){
        if (!character.AttackInTheTurn) {
            caixaTurnAttack.SetActive(true);
            PlayerCharactersSkills.Character = character;
        }
    }
}
