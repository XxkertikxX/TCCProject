using UnityEngine;

[CreateAssetMenu(menuName = "SkillsCrowdControlCreator")]
public class ScrSkillsCrowdControl : SkillBase
{
    public override void Skill(float power, float rhythmDamage) {
        ManaSystem.Mp.ModifyValue(-ManaConsume);
        foreach (var target in TargetType.Targets()) {
            target.AttackInTheTurn = true;
        }
    }
}