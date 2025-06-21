using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    [SerializeField] GameObject CaixaTurnAttack;
    
    public void ClickCharacter(StatusCharacters Character){
        if(!Character.AttackInTheTurn){
            Character.AttackInTheTurn = true;
        }
    }
}
