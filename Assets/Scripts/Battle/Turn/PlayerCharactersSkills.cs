using System.Collections;
using UnityEngine;

public class PlayerCharactersSkills : MonoBehaviour
{
    static public CharacterAttributes CharacterAttr;
    [SerializeField] private GameObject buttons;
    private SkillBase skill;

    public void PressButtonSkill(int posSkill) {
        StartCoroutine(StartRhythm(CharacterAttr.Rhythm, posSkill));
    }

    private IEnumerator StartRhythm(AttackRhythm rhythm, int posSkill) {
        skill = CharStatus().skills[posSkill];
        buttons.SetActive(false);
        rhythm.ActiveRhythm(true);
        return rhythm.Attack(skill);
        rhythm.ActiveRhythm(false);
        UseSkill(rhythm.Damage);
    }

    private void UseSkill(float rhythmDamage) {
        skill.Skill(CharStatus().power, rhythmDamage);
        CharacterAttr.AttackInTheTurn = true;
    }
    
    private StatusCharacters CharStatus(){
        return CharacterAttr.Character;
    }
}