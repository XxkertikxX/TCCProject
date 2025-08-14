using UnityEngine;

[CreateAssetMenu(menuName = "SkillsCrowdControlCreator")]
public class ScrSkillsCrowdControl : SkillBase
{
    public override void Skill(float power, float rhythmDamage) {
        ManaSystem.ModifyMana(-ManaConsume);
        foreach (var target in TargetType.Targets()) {
            target.AttackInTheTurn = true;
        }
    }
}