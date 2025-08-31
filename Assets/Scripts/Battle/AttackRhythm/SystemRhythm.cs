using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemRhythm : MonoBehaviour
{
    private AttackRhythm attackRhythm;

    public void Constructor(AttackRhythm attackRhythm) {
        this.attackRhythm = attackRhythm;
    }

    void Update() {
        attackRhythm.UpdateAttack();
    }

    void FixedUpdate() {
        attackRhythm.FixedUpdateAttack();
    }
}
