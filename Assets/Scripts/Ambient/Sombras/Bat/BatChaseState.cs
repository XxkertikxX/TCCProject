using UnityEngine;

public class BatChaseState : IBatState
{
    private BatStateMachine bat;
    private float chaseSpeed = 25f;

    public BatChaseState(BatStateMachine bat) {
        this.bat = bat;
    }

    public void Enter() => bat.Alert.SetActive(true);

    public void Update() {
        if (bat.HideAbility.Hide || !bat.IsPlayerInsideArea()) {
            bat.ChangeState(bat.PatrolState);
            return;
        }
        Vector3 target = bat.Player.position - bat.transform.position;
        bat.Movement.Move(target, chaseSpeed);
        bat.Movement.Look(target);
    }

    public void Exit() {
        bat.Movement.Stop();
    }
}