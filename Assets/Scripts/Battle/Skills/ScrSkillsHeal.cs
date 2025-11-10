using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "SkillsHealCreator")]
public class ScrSkillsHeal : SkillBase
{
    public override void Skill(float power, AttackRhythm rhythm) {
        float heal = (1+power)/100 * (rhythm.Damage) * SkillPower;
        float roundHeal = Mathf.Round(heal);
		TextBattleData.Action = $"curou {roundHeal} de vida ";
        foreach (var target in TargetType.CharactersAttributes) {
            target.LifeSystem.ModifyValue(roundHeal);
        }
    }
}