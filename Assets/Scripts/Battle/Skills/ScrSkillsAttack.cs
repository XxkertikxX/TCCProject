using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "SkillsAttackCreator")]
public class ScrSkillsAttack : SkillBase
{
    public override void Skill(float power, AttackRhythm rhythm) {
        float damage = (1+power)/100 * (rhythm.Damage) * SkillPower;
        float RoundDamage = -Mathf.Round(damage);
		TextBattleData.Action = $"causou {RoundDamage} de dano em ";
        foreach (var target in TargetType.CharactersAttributes) {
            target.LifeSystem.ModifyValue(RoundDamage);
        }
    }
}