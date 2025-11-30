using UnityEngine;

[RequireComponent(typeof(RbMovement))]
public class BatStateMachine : MonoBehaviour
{
    public GameObject Alert;

    public Collider2D TriggerArea;
    public RbMovement Movement { get; private set; }
    public Transform Player;
    public HideAbility HideAbility;

    public IBatState CurrentState { get; private set; }
    public BatPatrolState PatrolState { get; private set; }
    public BatChaseState ChaseState { get; private set; }

    private void Awake() {
        Movement = GetComponent<RbMovement>();

        PatrolState = new BatPatrolState(this);
        ChaseState = new BatChaseState(this);
    }

    void Enable() {
        SaveTrigger.OnDeath += ChangeStateToPatrol;
    }

    void Disable() {
        SaveTrigger.OnDeath -= ChangeStateToPatrol;
    }

    void Start() {
        ChangeState(PatrolState);
    }

    void FixedUpdate() {
        CurrentState?.Update();
    }

    public void ChangeState(IBatState newState) {
        CurrentState?.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }

    public bool IsPlayerInsideArea() {
		Vector2 playerPos2D = new Vector2(Player.position.x, Player.position.y);
		return TriggerArea.OverlapPoint(playerPos2D);
    }

    private void ChangeStateToPatrol() {
        CurrentState?.Exit();
        CurrentState = PatrolState;
        CurrentState.Enter();
    }
}