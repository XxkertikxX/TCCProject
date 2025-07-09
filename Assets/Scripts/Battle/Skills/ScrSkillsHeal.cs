using UnityEngine;

[CreateAssetMenu(menuName = "SkillsHealCreator")]
public class ScrSkillsHeal : SkillBase
{
    public override void Skill(float power) {
        float heal = power * (CatalystSkills.Damage / TimesForInvoke);
        float roundHeal = Mathf.Round(heal);
        TargetType.targets()[0].Hp.Heal(roundHeal);
    }
}