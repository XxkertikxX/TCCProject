using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "SkillsAttackCreator")]
public class ScrSkillsAttack : SkillBase
{
    public override IEnumerator Skill(float power, float rhythmDamage) {
        yield return TargetType.Targets();
        ManaSystem.Mp.ModifyValue(-ManaConsume);
        float damage = power * (rhythmDamage / TimesForInvoke);
        float RoundDamage = -Mathf.Round(damage);
        foreach (var target in TargetType.CharactersAttributes) {
            target.LifeSystem.ModifyValue(RoundDamage);
        }
    }
}