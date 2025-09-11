using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "SkillsHealCreator")]
public class ScrSkillsHeal : SkillBase
{
    public override IEnumerator Skill(float power, AttackRhythm rhythm) {
        yield return TargetType.Targets();
        yield return rhythm.Attack(this);
        ManaSystem.Mp.ModifyValue(-ManaConsume);
        float heal = power * (rhythm.Damage / TimesForInvoke);
        float roundHeal = Mathf.Round(heal);
        foreach (var target in TargetType.CharactersAttributes) {
            target.LifeSystem.ModifyValue(roundHeal);
        }
    }
}