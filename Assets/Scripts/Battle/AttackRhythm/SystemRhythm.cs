using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemRhythm : MonoBehaviour
{
    private IUpdateRhythm updateRhythm;

    public void Constructor(IUpdateRhythm updateRhythm) {
        this.updateRhythm = updateRhythm;
    }

    void Update() {
        updateRhythm.UpdateAttack();
    }

    void FixedUpdate() {
        updateRhythm.FixedUpdateAttack();
    }
}
