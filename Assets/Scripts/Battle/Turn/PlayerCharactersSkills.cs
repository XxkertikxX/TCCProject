using System.Collections;
using UnityEngine;

public class PlayerCharactersSkills : MonoBehaviour
{
    static public CharacterAttributes CharacterAttr;
    [SerializeField] private SystemRhythm systemRhythm;
    [SerializeField] private GameObject buttons;
    private SkillBase skill;

    public void PressButtonSkill(int posSkill) {
        StartCoroutine(StartRhythm(CharacterAttr.Rhythm, posSkill));
    }

    private IEnumerator StartRhythm(AttackRhythm rhythm, int posSkill) {
        skill = CharStatus().Skills[posSkill];
        buttons.SetActive(false);
        ActiveSystemRhythm(rhythm);
        yield return rhythm.Attack(skill);
        systemRhythm.enabled = false;
        UseSkill(rhythm.Damage);
    }

    private void ActiveSystemRhythm(AttackRhythm rhythm) {
        systemRhythm.enabled = true;
        systemRhythm.Constructor(rhythm);
    }

    private void UseSkill(float rhythmDamage) {
        StartCoroutine(skill.Skill(CharStatus().Power, rhythmDamage));
        CharacterAttr.AttackInTheTurn = true;
    }
    
    private StatusCharacters CharStatus() {
        return CharacterAttr.Character;
    }
}