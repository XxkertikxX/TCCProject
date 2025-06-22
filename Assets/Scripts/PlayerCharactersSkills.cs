using System.Collections.Generic;
using UnityEngine;

public class PlayerCharactersSkills : MonoBehaviour
{
    public StatusCharacters character;

    void OnEnable() {
        TextUpdate();
    }
    
    public void PressButtonSkill(int PosSkill) {
        character.skills[PosSkill].Skill();
        character.AttackInTheTurn = true;
        gameObject.SetActive(false);
    }

    void TextUpdate() {
        
    }
}