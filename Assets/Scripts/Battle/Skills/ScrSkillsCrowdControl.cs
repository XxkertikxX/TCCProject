using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "SkillsCrowdControlCreator")]
public class ScrSkillsCrowdControl : SkillBase
{
    public override void Skill(float power, AttackRhythm rhythm) {
        ManaSystem.Mp.ModifyValue(-ManaConsume);
        foreach (var target in TargetType.CharactersAttributes) {
            target.TurnsForCanAttack += SkillPower;
        }
    }
}