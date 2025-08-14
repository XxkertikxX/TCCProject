using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "TargetEnemy")]
public class TargetEnemy : TypeSkill
{
    public override List<CharacterAttributes> Targets() {
        List<CharacterAttributes> characterStatus = new List<CharacterAttributes>();
        characterStatus.Add(Enemy().GetComponent<CharacterAttributes>());
        return characterStatus;
    }

    private GameObject Enemy() {
        return GameObject.FindGameObjectWithTag("Enemy");
    }
}
