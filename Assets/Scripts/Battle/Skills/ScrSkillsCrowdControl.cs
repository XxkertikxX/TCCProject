using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "SkillsCrowdControlCreator")]
public class ScrSkillsCrowdControl : SkillBase
{
    public override IEnumerator Skill(float power, float rhythmDamage) {
        ManaSystem.Mp.ModifyValue(-ManaConsume);
        yield return TargetType.Targets();
        foreach (var target in TargetType.CharactersAttributes) {
            target.AttackInTheTurn = true;
        }
    }
}