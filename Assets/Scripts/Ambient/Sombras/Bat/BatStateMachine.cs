using UnityEngine;

[RequireComponent(typeof(RbMovement))]
public class BatStateMachine : MonoBehaviour
{
    public GameObject Alert;

    public Collider2D TriggerArea;
    public RbMovement Movement { get; private set; }
    public Transform Player { get; private set; }
    public HideAbility HideAbility { get; private set; }

    public IBatState CurrentState { get; private set; }
    public BatPatrolState PatrolState { get; private set; }
    public BatChaseState ChaseState { get; private set; }

    private void Awake() {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        HideAbility = Player.GetComponent<HideAbility>();
        Movement = GetComponent<RbMovement>();

        PatrolState = new BatPatrolState(this);
        ChaseState = new BatChaseState(this);
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
        return TriggerArea.bounds.Contains(Player.position);
    }
}