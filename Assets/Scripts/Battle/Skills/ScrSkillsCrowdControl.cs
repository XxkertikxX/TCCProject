using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "SkillsCrowdControlCreator")]
public class ScrSkillsCrowdControl : SkillBase
{
    public override void Skill(float power, AttackRhythm rhythm) {
		TextBattleData.Targets = TargetsString();
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
	
	public override string TargetsString() {
		List<CharactersAttributes> attributes = TargetType.CharactersAttributes;
		if(TargetType.CharactersAttributes.Count == 1) {
			return $"{attributes[0].CharacterStatus.Name}.";
		}
		string a = null;
        for(int i = 0; i < attributes.Count-1; i++) {
            a += $"{attributes[i].CharacterStatus.Name}, ";
        }
		a += $"{attributes[attributes.Count-1].CharacterStatus.Name}.";
		return a;
	}
}