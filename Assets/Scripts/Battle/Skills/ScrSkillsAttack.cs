using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "SkillsAttackCreator")]
public class ScrSkillsAttack : SkillBase
{
    public override void Skill(float power, AttackRhythm rhythm) {
        float damage = (power)/100 * (rhythm.Damage) * SkillPower;
        float RoundDamage = -Mathf.Round(damage);
		TextBattleData.Action = $"causou {RoundDamage} de dano em ";
		TextBattleData.Targets = TargetsString();
        foreach (var target in TargetType.CharactersAttributes) {
            CharacterClick.CharacterAttr.Character.Xp += target.LifeSystem.ModifyValue(RoundDamage*target.Character.DamageReduction());
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