using System.Collections;
using UnityEngine;

public class PlayerCharactersSkills : MonoBehaviour
{
    [SerializeField] private SystemRhythm systemRhythm;
    [SerializeField] private GameObject boxSkill;
    private SkillBase skill;

    public void PressButtonSkill(int posSkill) {
        StartCoroutine(ActiveSkill(posSkill));
    }

    private IEnumerator ActiveSkill(int posSkill) {
        AttackRhythm rhythm = CharacterClick.CharacterAttr.Rhythm;
        skill = CharStatus().Skills[posSkill];
        boxSkill.SetActive(false);
        ActiveSystemRhythm(rhythm);
        yield return UseSkill(rhythm);
        systemRhythm.enabled = false;
    }

    private void ActiveSystemRhythm(AttackRhythm rhythm) {
        systemRhythm.enabled = true;
        systemRhythm.Constructor(rhythm.gameObject.GetComponent<IUpdateRhythm>());
    }

    private IEnumerator UseSkill(AttackRhythm rhythm) {
        yield return skill.TargetType.Targets();
        yield return rhythm.Attack(skill);
        skill.Skill(CharStatus().Power, rhythm);
        CharacterClick.CharacterAttr.TurnsForCanAttack += 1;
    }
    
    private StatusCharacters CharStatus() {
        return CharacterClick.CharacterAttr.Character;
    }
}