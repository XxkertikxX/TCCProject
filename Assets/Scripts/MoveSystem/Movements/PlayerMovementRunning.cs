using UnityEngine;

public class PlayerMovementRunning  : MonoBehaviour, IMovement
{
    private float multiplierSpeed;
    
    public void Move(Rigidbody2D rb, MovementProperties movementProperties) {
        movementProperties.MultiplierSpeed =  multiplierSpeed;
    }
    
    public bool Apply(IButtonInput input) {
        MultiplierSpeedCalculator(input);
        return true;
    }
    
    private void MultiplierSpeedCalculator(IButtonInput input) {
        if(input.InputButton("Run")) {
            multiplierSpeed = 1.5f;
            return;
        }
        multiplierSpeed = 1f;
    }
}