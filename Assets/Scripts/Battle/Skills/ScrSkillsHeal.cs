using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "SkillsHealCreator")]
public class ScrSkillsHeal : SkillBase
{
    public override void Skill(float power, AttackRhythm rhythm) {
        float heal = (power)/100 * (rhythm.Damage) * SkillPower;
        float roundHeal = Mathf.Round(heal);
		TextBattleData.Action = $"curou {roundHeal} de vida ";
		TextBattleData.Targets = TargetsString();
        foreach (var target in TargetType.CharactersAttributes) {
            CharacterClick.CharacterAttr.Character.Xp += Mathf.Abs(target.LifeSystem.ModifyValue(roundHeal));
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