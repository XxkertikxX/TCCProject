using System.Collections;
using UnityEngine;

public class PlayerCharactersSkills : MonoBehaviour
{
    static public bool OnBattle = false;

    [SerializeField] private SystemRhythm systemRhythm;
    [SerializeField] private GameObject boxSkill;
	[SerializeField] private GameObject painel;
    [SerializeField] private Event applySkill;
	[SerializeField] private Event useSkill;

    private SkillBase skill;

	public void PressButtonSkill(int posSkill) {
		Texts(posSkill);
		float manaConsume = CharStatus().Skills[posSkill].ManaConsume;
		if(ManaSystem.Mp.CanChangeResource(manaConsume)) {
            OnBattle = true;
            StartCoroutine(ActiveSkill(posSkill, manaConsume));
        }
    }

    private IEnumerator ActiveSkill(int posSkill, float manaConsume) {
		useSkill.EventInvoke();
        boxSkill.SetActive(false);
		yield return new WaitUntil(() => DialogManager.OnDialog == false);
        AttackRhythm rhythm = CharacterClick.CharacterAttr.Rhythm;
        skill = CharStatus().Skills[posSkill];
        yield return SystemRhythmCicle(rhythm, manaConsume);
        Character().Anim.SetTrigger(Character().AnimString);
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
        yield return PassTurn(rhythm, manaConsume);
    }
    
    private IEnumerator Attack(AttackRhythm rhythm) {
		painel.SetActive(true);
        yield return rhythm.Attack(skill);
        EnemyAnim.PlayTrigger("TookDamage");
        painel.SetActive(false);


    }

    private IEnumerator PassTurn(AttackRhythm rhythm, float manaConsume) {
        skill.Skill(CharStatus().Power, rhythm);
        applySkill.EventInvoke();
		yield return new WaitUntil(() => DialogManager.OnDialog == false);
        Character().TurnsForCanAttack += 1;
		ManaSystem.Mp.ModifyValue(-manaConsume);
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
}