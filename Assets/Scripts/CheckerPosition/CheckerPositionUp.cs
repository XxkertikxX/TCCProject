using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CheckerPositionUp")]
public class CheckerPositionUp : CheckerPosition {
    public override float Axis(Transform transform) {
        return transform.position.y;
    }

    public override bool PassedDistance(Transform firstTransform, Transform secondTransform) {
        return Axis(firstTransform) > Axis(secondTransform);
    }
}