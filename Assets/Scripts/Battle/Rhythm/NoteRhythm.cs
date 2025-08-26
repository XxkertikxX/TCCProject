using UnityEngine;

public class NoteRhythm : MonoBehaviour
{
    public Directions Direction;
    
    void Awake() {
        gameObject.AddComponent<RbMovement>();
    }

    public float PerDamage(Transform center, float AreaSize) {
        float distance = Mathf.Abs(Direction.Checker.Axis(transform) - Direction.Checker.Axis(center));
        return 1f - (distance / (AreaSize / 2f));
    }

    public bool DestroyLineOutLimits() {
        return Direction.Checker.PassedDistance(transform, Direction.point.transform);
    }
}