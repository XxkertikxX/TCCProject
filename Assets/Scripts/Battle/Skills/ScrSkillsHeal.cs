using UnityEngine;

[CreateAssetMenu(menuName = "SkillsHealCreator")]
public class ScrSkillsHeal : SkillBase
{
    public override void Skill(float power, float rhythmDamage) {
        ManaSystem.Mp.ModifyValue(-ManaConsume);
        float heal = power * (rhythmDamage / TimesForInvoke);
        float roundHeal = Mathf.Round(heal);
        foreach (var target in TargetType.Targets()) {
            target.LifeSystem.ModifyValue(roundHeal);
        }
    }
}