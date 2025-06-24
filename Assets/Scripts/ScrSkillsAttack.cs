using UnityEngine;

[CreateAssetMenu(menuName = "SkillsAttackCreator")]
public class ScrSkillsAttack : SkillBase
{
    public override void Skill(float power, hp target)
    {
        float Damage = power * (CatalystSkills.Damage / TimesForInvoke);
        float RoundDamage = Mathf.Round(Damage);
        target.TakeDamage(RoundDamage);
    }
}