using UnityEngine;

public class NoteMovement : MonoBehaviour
{
    public RbMovement Rb;
    public Directions Direction;
    public Notes Note;
    public NoteFadeInFadeOut Fade;

    void Awake() {
        Rb = gameObject.AddComponent<RbMovement>();
        Rb.ResetGravityScale();
    }

    public float PerDamage() {		
        float centerDistance = (Distance()/(Bounds()));
        centerDistance = Mathf.Clamp01(centerDistance);
        float damage = 0.5f + (1 - centerDistance) * 0.5f;
        return damage;
    }

    public bool VerifyLineOutLimits() {
        return Direction.Checker.PassedDistance(transform, Direction.Point.transform);
    }

    public float Distance() {
        return Mathf.Abs(Direction.Checker.Axis(transform) - Direction.Checker.Axis(Direction.CenterLine));
    }
	
	public int Index() {
		if(Direction.Checker.PassedDistance(transform, Direction.CenterLine.transform)) {
			return 1;
		}
		return 0;
	}
	
	public float Bounds() {
		if(Direction.Distances[Index()].bounds.size.x > Direction.Distances[Index()].bounds.size.y) {
			return Direction.Distances[Index()].bounds.size.x;
		}
		return Direction.Distances[Index()].bounds.size.y;
	}
}