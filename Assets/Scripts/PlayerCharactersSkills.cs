using UnityEngine;

public class PlayerCharactersSkills : MonoBehaviour
{
    public StatusCharacters character;

    void OnEnable() {
        TextUpdate();
    }
    
    public void PressButtonSkill(int PosSkill) {
        character.skills[PosSkill].Skill(character.damage, Enemyhp());
        character.AttackInTheTurn = true;
        gameObject.SetActive(false);
    }

    hp Enemyhp() {
        return GameObject.FindGameObjectWithTag("Enemy").GetComponent<hp>();
    }
    
    void TextUpdate() {
        
    }
}