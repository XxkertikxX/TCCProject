using System.Collections;
using UnityEngine;
using System;

public class PlayerCharactersSkills : MonoBehaviour
{
    static public bool OnBattle = false;
    [SerializeField] private SystemRhythm systemRhythm;
    [SerializeField] private GameObject boxSkill;
	[SerializeField] private GameObject painel;
    [SerializeField] private Event applySkill;
	[SerializeField] private Event useSkill;

    private SkillBase skill;

	public void PressButtonSkill(int posSkill) { // usar character().anim com o posSkill pra botar ambas animações inves do trigger
		Texts(posSkill);
		float manaConsume = CharStatus().Skills[posSkill].ManaConsume;
		if(ManaSystem.Mp.CanChangeResource(manaConsume)) {
            OnBattle = true;
			ChangeSpeedRhythm(posSkill);
            StartCoroutine(ActiveSkill(posSkill, manaConsume));
        }
    }

    public void MouseIsOverButton(int posSkill)  {
        float manaConsume = CharStatus().Skills[posSkill].ManaConsume;
        ManaSliderDiference.manaCust = manaConsume;
    }
    
    private IEnumerator ActiveSkill(int posSkill, float manaConsume) {
		useSkill.EventInvoke();
        ManaSystem.Mp.ModifyValue(-manaConsume);
        boxSkill.SetActive(false);
        yield return new WaitUntil(() => DialogManager.OnDialog == false);
        AttackRhythm rhythm = CharacterClick.CharacterAttr.Rhythm;
        skill = CharStatus().Skills[posSkill];
        yield return SystemRhythmCicle(rhythm, manaConsume, posSkill);
        CharacterClick.CharacterAttr = null;
    }

    private IEnumerator SystemRhythmCicle(AttackRhythm rhythm, float manaConsume, int posSkill) {
        ActiveSystemRhythm(rhythm);
        yield return UseSkill(rhythm, manaConsume, posSkill);
        systemRhythm.enabled = false;
    }

    private IEnumerator CreateSkillVisual(int posSkill) {
        Character().Anim.SetTrigger(Character().AnimString);
        for (int i = 0; i < Character().multipleAttacks[posSkill]; i++) {
            Instantiate(Character().attackAnimations[posSkill]);
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void ActiveSystemRhythm(AttackRhythm rhythm) {
        systemRhythm.enabled = true;
        systemRhythm.Constructor(rhythm.gameObject.GetComponent<IUpdateRhythm>());
    }
	
    private IEnumerator UseSkill(AttackRhythm rhythm, float manaConsume, int posSkill) {
        yield return skill.TargetType.Targets();
		yield return Attack(rhythm);
        yield return PassTurn(rhythm, manaConsume, posSkill);
    }
    
    private IEnumerator Attack(AttackRhythm rhythm) {
		painel.SetActive(true);
        yield return rhythm.Attack(skill);
        painel.SetActive(false);
    }

    private IEnumerator PassTurn(AttackRhythm rhythm, float manaConsume, int posSkill) {
        StartCoroutine(CreateSkillVisual(posSkill));
        yield return new WaitForSeconds(2f);
        skill.Skill(CharStatus().Power, rhythm);
        applySkill.EventInvoke();
		yield return new WaitUntil(() => DialogManager.OnDialog == false);
        Character().TurnsForCanAttack += 1;
        OnBattle = false;
    }
	
	private CharacterAttributes Character() {
		return CharacterClick.CharacterAttr;
	}
	
    private StatusCharacters CharStatus() {
        return Character().Character;
    }
	
	private void Texts(int posSkill) {
		TextBattleData.Character = CharStatus().Name;
		TextBattleData.SkillName = CharStatus().Skills[posSkill].Name;
	}
	
	private void ChangeSpeedRhythm(int posSkill) {
		RhythmProperties.SpeedMin = CharStatus().Skills[posSkill].SpeedMin;
		RhythmProperties.SpeedMax = CharStatus().Skills[posSkill].SpeedMax;
	}
}