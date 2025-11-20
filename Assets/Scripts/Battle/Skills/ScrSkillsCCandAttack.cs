using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "SkillsCCandAttackCreator")]
public class ScrSkillsCCandAttack : SkillBase
{
    public override void Skill(float power, AttackRhythm rhythm) {
		float damage = (1+power)/100 * (rhythm.Damage) * SkillPower;
        float RoundDamage = -Mathf.Round(damage);
		TextBattleData.Targets = TargetsString();
        foreach (var target in TargetType.CharactersAttributes) {
            target.LifeSystem.ModifyValue(RoundDamage*target.Character.DamageReduction());
			if(rhythm.Damage >= 0.9f) {
				target.TurnsForCanAttack += 1;
				TextBattleData.Action = $"causou {RoundDamage} de dano e stunou por {1} rounds ";
			}
			else{
				TextBattleData.Action = $"causou {RoundDamage} de dano e falhou em stunar ";
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
