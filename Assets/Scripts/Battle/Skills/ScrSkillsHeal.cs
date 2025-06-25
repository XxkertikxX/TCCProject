using UnityEngine;

[CreateAssetMenu(menuName = "SkillsHealCreator")]
public class ScrSkillsHeal : SkillBase
{
    public override void Skill(float power, hp target) {
        float Heal = power * (CatalystSkills.Damage / TimesForInvoke);
        float RoundHeal = Mathf.Round(Heal);
        target.Heal(RoundHeal);
    }
}