using UnityEngine;

[CreateAssetMenu(menuName = "SkillsHealCreator")]
public class ScrSkillsHeal : SkillBase
{
    public override void Skill(float power) {
        ManaSystemscr.ModifyMana(-ManaConsume);
        float heal = power * (CatalystSkills.Damage / TimesForInvoke);
        float roundHeal = Mathf.Round(heal);
        foreach (var target in TargetType.targets()) {
            target.Hp.ModifyLife(roundHeal);
        }
    }
}