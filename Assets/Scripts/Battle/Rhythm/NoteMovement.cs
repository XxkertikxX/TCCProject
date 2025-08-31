using UnityEngine;

public class NoteMovement : MonoBehaviour
{
    public RbMovement Rb;
    public Directions Direction;
    
    void Awake() {
        Rb = gameObject.AddComponent<RbMovement>();
        Rb.ResetGravityScale();
    }

    public float PerDamage(Transform center, float AreaSize) {
        float distance = Mathf.Abs(Direction.Checker.Axis(transform) - Direction.Checker.Axis(center));
        return 1f - (distance / (AreaSize / 2f));
    }

    public bool DestroyLineOutLimits() {
        return Direction.Checker.PassedDistance(transform, Direction.point.transform);
    }
}