using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "SkillsCrowdControlCreator")]
public class ScrSkillsCrowdControl : SkillBase
{
    public override IEnumerator Skill(float power, AttackRhythm rhythm) {
        yield return TargetType.Targets();
        yield return rhythm.Attack(this);
        ManaSystem.Mp.ModifyValue(-ManaConsume);
        foreach (var target in TargetType.CharactersAttributes) {
            target.TurnsForCanAttack += SkillPower;
        }
    }
}