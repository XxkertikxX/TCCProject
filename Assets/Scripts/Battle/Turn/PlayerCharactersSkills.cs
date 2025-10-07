using System.Collections;
using UnityEngine;

public class PlayerCharactersSkills : MonoBehaviour
{
    [SerializeField] private SystemRhythm systemRhythm;
    [SerializeField] private GameObject boxSkill;
	[SerializeField] private GameObject painel;
    [SerializeField] private Event eventDialog;

    private SkillBase skill;

    public void PressButtonSkill(int posSkill) {
		float manaConsume = CharStatus().Skills[posSkill].ManaConsume;
		if(ManaSystem.Mp.CanChangeResource(manaConsume)) StartCoroutine(ActiveSkill(posSkill, manaConsume));
    }

    private IEnumerator ActiveSkill(int posSkill, float manaConsume) {
        AttackRhythm rhythm = CharacterClick.CharacterAttr.Rhythm;
        skill = CharStatus().Skills[posSkill];
        boxSkill.SetActive(false);
        yield return SystemRhythmCicle(rhythm, manaConsume);
    }

    private IEnumerator SystemRhythmCicle(AttackRhythm rhythm, float manaConsume) {
        ActiveSystemRhythm(rhythm);
        yield return UseSkill(rhythm, manaConsume);
        systemRhythm.enabled = false;
    }
    
    private void ActiveSystemRhythm(AttackRhythm rhythm) {
        systemRhythm.enabled = true;
        systemRhythm.Constructor(rhythm.gameObject.GetComponent<IUpdateRhythm>());
    }
	
    private IEnumerator UseSkill(AttackRhythm rhythm, float manaConsume) {
        yield return skill.TargetType.Targets();
		yield return Attack(rhythm);
        PassTurn(rhythm, manaConsume);
    }
    
    private IEnumerator Attack(AttackRhythm rhythm) {
		painel.SetActive(true);
        yield return rhythm.Attack(skill);
		painel.SetActive(false);
        eventDialog.EventInvoke();
    }

    private void PassTurn(AttackRhythm rhythm, float manaConsume) {
        skill.Skill(CharStatus().Power, rhythm);
        CharacterClick.CharacterAttr.TurnsForCanAttack += 1;
		ManaSystem.Mp.ModifyValue(-manaConsume);
    }

    private StatusCharacters CharStatus() {
        return CharacterClick.CharacterAttr.Character;
    }
}