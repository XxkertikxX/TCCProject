using UnityEngine;

[CreateAssetMenu(menuName = "SkillsHealCreator")]
public class ScrSkillsHeal : SkillBase
{
    public override void Skill(float power) {
        float Heal = power * (CatalystSkills.Damage / TimesForInvoke);
        float RoundHeal = Mathf.Round(Heal);
        targetType.targets()[0].Hp.Heal(RoundHeal);
    }
}