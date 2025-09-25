using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "SkillsHealCreator")]
public class ScrSkillsHeal : SkillBase
{
    public override void Skill(float power, AttackRhythm rhythm) {
        float heal = power * (rhythm.Damage) + SkillPower;
        float roundHeal = Mathf.Round(heal);
        foreach (var target in TargetType.CharactersAttributes) {
            target.LifeSystem.ModifyValue(roundHeal);
        }
    }
}