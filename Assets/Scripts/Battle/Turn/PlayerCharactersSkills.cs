using System.Collections;
using UnityEngine;

public class PlayerCharactersSkills : MonoBehaviour
{
    [SerializeField] private SystemRhythm systemRhythm;
    [SerializeField] private GameObject boxSkill;
    private SkillBase skill;

    public void PressButtonSkill(int posSkill) {
        StartCoroutine(StartRhythm(CharacterClick.CharacterAttr.Rhythm, posSkill));
    }

    private IEnumerator StartRhythm(AttackRhythm rhythm, int posSkill) {
        skill = CharStatus().Skills[posSkill];
        boxSkill.SetActive(false);
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
        CharacterClick.CharacterAttr.TurnsForCanAttack += 1;
    }
    
    private StatusCharacters CharStatus() {
        return CharacterClick.CharacterAttr.Character;
    }
}