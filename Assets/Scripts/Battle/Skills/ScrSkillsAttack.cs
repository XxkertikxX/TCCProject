using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "SkillsAttackCreator")]
public class ScrSkillsAttack : SkillBase
{
    public override IEnumerator Skill(float power, AttackRhythm rhythm) {
        yield return TargetType.Targets();
        yield return rhythm.Attack(this);
        ManaSystem.Mp.ModifyValue(-ManaConsume);
        float damage = power * (rhythm.Damage / TimesForInvoke);
        float RoundDamage = -Mathf.Round(damage);
        foreach (var target in TargetType.CharactersAttributes) {
            target.LifeSystem.ModifyValue(RoundDamage);
        }
    }
    
}