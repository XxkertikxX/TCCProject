using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "SkillsHealCreator")]
public class ScrSkillsHeal : SkillBase
{
    public override void Skill(float power, AttackRhythm rhythm) {
        float heal = (1+power)/100 * (rhythm.Damage) * SkillPower;
        float roundHeal = Mathf.Round(heal);
		TextBattleData.Action = $"curou {roundHeal} de vida ";
		TextBattleData.Targets = TargetsString();
        foreach (var target in TargetType.CharactersAttributes) {
            target.LifeSystem.ModifyValue(roundHeal);
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