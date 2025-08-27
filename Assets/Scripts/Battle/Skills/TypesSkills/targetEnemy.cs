using UnityEngine;
using System.Collections.Generic;
using System.Collections;

[CreateAssetMenu(menuName = "TargetEnemy")]
public class TargetEnemy : TypeSkill
{
    public override IEnumerator Targets() {
        List<CharacterAttributes> characterStatus = new List<CharacterAttributes>();
        characterStatus.Add(Enemy().GetComponent<CharacterAttributes>());
        CharactersAttributes = characterStatus;
        yield return null;
    }

    private GameObject Enemy() {
        return GameObject.FindGameObjectWithTag("Enemy");
    }
}
