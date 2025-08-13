using UnityEngine;

[CreateAssetMenu(menuName = "SkillsHealCreator")]
public class ScrSkillsHeal : SkillBase
{
    public override void Skill(float power, float rhythmDamage) {
        ManaSystemscr.ModifyMana(-ManaConsume);
        float heal = power * (rhythmDamage / TimesForInvoke);
        float roundHeal = Mathf.Round(heal);
        foreach (var target in TargetType.Targets()) {
            target.Hp.ModifyLife(roundHeal);
        }
    }
}