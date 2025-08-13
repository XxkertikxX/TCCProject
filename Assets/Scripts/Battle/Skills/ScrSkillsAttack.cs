using UnityEngine;

[CreateAssetMenu(menuName = "SkillsAttackCreator")]
public class ScrSkillsAttack : SkillBase
{
    public override void Skill(float power, float rhythmDamage) {
        ManaSystemscr.ModifyMana(-ManaConsume);
        float damage = power * (rhythmDamage / TimesForInvoke);
        float RoundDamage = -Mathf.Round(damage);
        foreach (var target in TargetType.targets()) {
            target.Hp.ModifyLife(RoundDamage);
        }
    }
}