using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "SkillsHealCreator")]
public class ScrSkillsHeal : SkillBase
{
    public override IEnumerator Skill(float power, float rhythmDamage) {
        ManaSystem.Mp.ModifyValue(-ManaConsume);
        float heal = power * (rhythmDamage / TimesForInvoke);
        float roundHeal = Mathf.Round(heal);
        yield return TargetType.Targets();
        foreach (var target in TargetType.CharactersAttributes) {
            target.LifeSystem.ModifyValue(roundHeal);
        }
    }
}