using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CheckerPositionRight")]
public class CheckerPositionRight : CheckerPosition {
    public override float Axis(Transform transform) {
        return transform.position.x;
    }

    public override bool PassedDistance(Transform firstTransform, Transform secondTransform) {
        return Axis(firstTransform) > Axis(secondTransform);
    }
}