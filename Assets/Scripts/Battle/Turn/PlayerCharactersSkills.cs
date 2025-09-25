using System.Collections;
using UnityEngine;

public class PlayerCharactersSkills : MonoBehaviour
{
    [SerializeField] private SystemRhythm systemRhythm;
    [SerializeField] private GameObject boxSkill;
	[SerializeField] private GameObject painel;
    private SkillBase skill;

    public void PressButtonSkill(int posSkill) {
		float manaConsume = CharStatus().Skills[posSkill].ManaConsume;
		if(manaConsume <= ManaSystem.Mp.ActualValue()) {
			StartCoroutine(ActiveSkill(posSkill, manaConsume));
		}
    }

    private IEnumerator ActiveSkill(int posSkill, float manaConsume) {
        AttackRhythm rhythm = CharacterClick.CharacterAttr.Rhythm;
        skill = CharStatus().Skills[posSkill];
        boxSkill.SetActive(false);
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
		painel.SetActive(true);
        yield return rhythm.Attack(skill);
		painel.SetActive(false);
        skill.Skill(CharStatus().Power, rhythm);
        CharacterClick.CharacterAttr.TurnsForCanAttack += 1;
		ManaSystem.Mp.ModifyValue(-manaConsume);
    }
    
    private StatusCharacters CharStatus() {
        return CharacterClick.CharacterAttr.Character;
    }
}