using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "SkillsCrowdControlCreator")]
public class ScrSkillsCrowdControl : SkillBase
{
    public override void Skill(float power, AttackRhythm rhythm) {
        foreach (var target in TargetType.CharactersAttributes) {
			if(rhythm.Damage >= 0.75f) {
				target.TurnsForCanAttack += SkillPower;
						TextBattleData.Action = $"stunou por {SkillPower} rounds ";

			}
			else{
				target.TurnsForCanAttack += SkillPower-1;
				TextBattleData.Action = $"stunou por {SkillPower-1} rounds ";
			}
        }
    }
}