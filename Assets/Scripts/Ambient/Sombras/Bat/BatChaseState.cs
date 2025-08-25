using UnityEngine;

public class BatChaseState : IBatState
{
    private BatStateMachine bat;
    private float chaseSpeed = 6f;

    public BatChaseState(BatStateMachine bat) {
        this.bat = bat;
    }

    public void Enter() => bat.Alert.SetActive(true);

    public void Update() {
        if (bat.HideAbility.Hide || !bat.IsPlayerInsideArea()) {
            bat.ChangeState(bat.PatrolState);
            return;
        }

        bat.Movement.Move(bat.Player.position - bat.transform.position, chaseSpeed);
    }

    public void Exit() {
        bat.Movement.Stop();
    }
}