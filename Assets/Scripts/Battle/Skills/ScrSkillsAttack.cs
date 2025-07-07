using UnityEngine;

[CreateAssetMenu(menuName = "SkillsAttackCreator")]
public class ScrSkillsAttack : SkillBase
{
    public override void Skill(float power) {
        float Damage = power * (CatalystSkills.Damage / TimesForInvoke);
        float RoundDamage = Mathf.Round(Damage);
    }
}