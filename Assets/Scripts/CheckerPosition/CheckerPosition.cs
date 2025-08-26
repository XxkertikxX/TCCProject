using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CheckerPosition : ScriptableObject {
    public abstract float Axis(Transform transform);
    public abstract bool PassedDistance(Transform firstTransform, Transform secondTransform);
}