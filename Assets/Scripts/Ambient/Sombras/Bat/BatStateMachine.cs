using UnityEngine;

[RequireComponent(typeof(BatMovement))]
public class BatStateMachine : MonoBehaviour
{
    public GameObject Alert;

    public Collider2D TriggerArea;
    public BatMovement Movement { get; private set; }
    public Transform Player { get; private set; }
    public HideAbility HideAbility { get; private set; }

    public IBatState CurrentState { get; private set; }
    public BatPatrolState PatrolState { get; private set; }
    public BatChaseState ChaseState { get; private set; }

    private void Awake() {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        HideAbility = Player.GetComponent<HideAbility>();
        Movement = GetComponent<BatMovement>();

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
        Debug.Log("Bat changed to state: " + newState.GetType().Name);
    }

    public bool IsPlayerInsideArea() {
        return TriggerArea.bounds.Contains(Player.position);
    }
}