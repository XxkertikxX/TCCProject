using UnityEngine;

[CreateAssetMenu(menuName = "SkillsCrowdControlCreator")]
public class ScrSkillsCrowdControl : SkillBase
{
    public override void Skill(float power) {
        MpSystemscr.ModifyMana(-ManaConsume);
        foreach (var target in TargetType.targets()) {
            target.AttackInTheTurn = true;
        }
    }
}