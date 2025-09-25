using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "SkillsCrowdControlCreator")]
public class ScrSkillsCrowdControl : SkillBase
{
    public override void Skill(float power, AttackRhythm rhythm) {
        foreach (var target in TargetType.CharactersAttributes) {
            target.TurnsForCanAttack += SkillPower;
        }
    }
}