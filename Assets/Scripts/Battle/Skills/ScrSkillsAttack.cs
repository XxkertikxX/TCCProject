using UnityEngine;

[CreateAssetMenu(menuName = "SkillsAttackCreator")]
public class ScrSkillsAttack : SkillBase
{
    public override void Skill(float power) {
        float damage = power * (CatalystSkills.Damage / TimesForInvoke);
        float RoundDamage = -Mathf.Round(damage);
        foreach (var target in TargetType.targets()) {
            target.Hp.AddLife(RoundDamage);
        }
    }
}