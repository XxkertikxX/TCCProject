using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "SkillsCrowdControlCreator")]
public class ScrSkillsCrowdControl : SkillBase
{
    public override IEnumerator Skill(float power, float rhythmDamage) {
        yield return TargetType.Targets();
        ManaSystem.Mp.ModifyValue(-ManaConsume);
        foreach (var target in TargetType.CharactersAttributes) {
            target.TurnsForCanAttack += SkillPower;
        }
    }
}