using UnityEngine;

public class BatPatrolState : IBatState
{
    private BatStateMachine bat;
    private Vector2 patrolTarget;

    private float patrolSpeed = 8f;

    public BatPatrolState(BatStateMachine bat) {
        this.bat = bat;
    }

    public void Enter() {
        SetRandomTarget();
        bat.Alert.SetActive(false);
    }

    public void Update() {
        SetNewTarget();
        bat.Movement.Move(patrolTarget - (Vector2)bat.transform.position, patrolSpeed);
        VerifyIfChangeState();
    }

    public void Exit() {
        bat.Movement.Stop();
    }
    
    private void VerifyIfChangeState() {
        float chaseProbability = 0.005f;
        bool mustChase = Random.value < chaseProbability;
        if (mustChase) {
            bat.ChangeState(bat.ChaseState);
        }
    }
    
    private void SetNewTarget() {
        if (Vector2.Distance(bat.transform.position, patrolTarget) < 0.1f){
            SetRandomTarget();
        }
    }
    
    private void SetRandomTarget() {
        Bounds bounds = bat.TriggerArea.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        patrolTarget = new Vector2(x, y);
    }
}
