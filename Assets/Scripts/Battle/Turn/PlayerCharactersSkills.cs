using System.Collections;
using UnityEngine;

public class PlayerCharactersSkills : MonoBehaviour
{
    [SerializeField] private SystemRhythm systemRhythm;
    [SerializeField] private GameObject boxSkill;
    private SkillBase skill;

    public void PressButtonSkill(int posSkill) {
        AttackRhythm rhythm = CharacterClick.CharacterAttr.Rhythm;
        skill = CharStatus().Skills[posSkill];
        boxSkill.SetActive(false);
        ActiveSystemRhythm(rhythm);
        systemRhythm.enabled = false;
        UseSkill(rhythm);
    }

    private void ActiveSystemRhythm(AttackRhythm rhythm) {
        systemRhythm.enabled = true;
        systemRhythm.Constructor(rhythm.gameObject.GetComponent<IUpdateRhythm>());
    }

    private void UseSkill(AttackRhythm rhythm) {
        StartCoroutine(skill.Skill(CharStatus().Power, rhythm));
        CharacterClick.CharacterAttr.TurnsForCanAttack += 1;
    }
    
    private StatusCharacters CharStatus() {
        return CharacterClick.CharacterAttr.Character;
    }
}