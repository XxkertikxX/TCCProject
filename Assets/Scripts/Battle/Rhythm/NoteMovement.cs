using UnityEngine;

public class NoteMovement : MonoBehaviour
{
    public RbMovement Rb;
    public Directions Direction;
    public Notes Note;
    
    void Awake() {
        Rb = gameObject.AddComponent<RbMovement>();
        Rb.ResetGravityScale();
    }

    public float PerDamage(float AreaSize) {
        float centerDistance = (Distance()/ (AreaSize / 2f));
        float damage = 0.7f + (1 - centerDistance * 0.3f);
        return damage;
    }

    public bool DestroyLineOutLimits() {
        return Direction.Checker.PassedDistance(transform, Direction.Point.transform);
    }

    public float Distance() {
        return Mathf.Abs(Direction.Checker.Axis(transform) - Direction.Checker.Axis(Direction.CenterLine));
    }
}