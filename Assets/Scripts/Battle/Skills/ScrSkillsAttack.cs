using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "SkillsAttackCreator")]
public class ScrSkillsAttack : SkillBase
{
    public override void Skill(float power, AttackRhythm rhythm) {
        ManaSystem.Mp.ModifyValue(-ManaConsume);
        float damage = power * (rhythm.Damage / TimesForInvoke);
        float RoundDamage = -Mathf.Round(damage);
        foreach (var target in TargetType.CharactersAttributes) {
            target.LifeSystem.ModifyValue(RoundDamage);
        }
    }
}