using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRhythm : AttackRhythm
{
    void Awake() {
        Damage = 1;
    }

    public override IEnumerator Attack(SkillBase skill) {
        yield return null;
    }
}