using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "SkillsCrowdControlCreator")]
public class ScrSkillsCrowdControl : SkillBase
{
    public override void Skill(float power, AttackRhythm rhythm) {
		TextBattleData.Targets = TargetsString();
        foreach (var target in TargetType.CharactersAttributes) {
			if(rhythm.Damage >= 0.96f) {
				target.TurnsForCanAttack += 1;
				TextBattleData.Action = $"stunou por 1 rounds ";
				CharacterClick.CharacterAttr.Character.Xp += 20;
			}
			else{
				TextBattleData.Action = $"falhou em stunar ";
			}
        }
    }
	
	public override string TargetsString() {
		List<CharacterAttributes> attributes = TargetType.CharactersAttributes;
		if(TargetType.CharactersAttributes.Count == 1) {
			return $"{attributes[0].Character.Name}.";
		}
		string a = null;
        for(int i = 0; i < attributes.Count-1; i++) {
            a += $"{attributes[i].Character.Name}, ";
        }
		a += $"{attributes[attributes.Count-1].Character.Name}.";
		return a;
	}
}