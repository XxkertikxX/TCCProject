using System.Collections;
using UnityEngine;

public class PlayerCharactersSkills : MonoBehaviour
{
    static public CharacterAttributes CharacterAttr;
    private SkillBase skill;

    public IEnumerator PressButtonSkill(int posSkill) {
        skill = CharStatus().skills[posSkill];
        gameObject.SetActive(false);
        return CharacterAttr.Rhythm.Attack(skill);
        UseSkill(posSkill);
    }

    private void UseSkill(int posSkill) {
        skill.Skill(CharStatus().power);
        CharacterAttr.AttackInTheTurn = true;
    }
    
    private StatusCharacters CharStatus(){
        return CharacterAttr.Character;
    }
}