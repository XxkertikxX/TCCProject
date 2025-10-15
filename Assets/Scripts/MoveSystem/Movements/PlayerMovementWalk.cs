using UnityEngine;

public class PlayerMovementWalk : MonoBehaviour, IMovement
{    
    private float inputDirection;
	private float runningSpeed;

    private bool running;
    public bool _running {  get; private set; }

    public void Move(Rigidbody2D rb, MovementProperties movementProperties) {
        rb.velocity = new Vector2(inputDirection * GetSpeed(movementProperties), rb.velocity.y);
    }

    public bool Apply(IButtonInput input) {
        InputDirectionCalculator(input);
		runningSpeed = MultiplierSpeedCalculator(input);
        return true;
    }

    private void InputDirectionCalculator(IButtonInput input) {
        inputDirection = 0f;
        inputDirection -= GetDirectionX(input, "Left");
        inputDirection += GetDirectionX(input, "Right");
    }

    private float GetDirectionX(IButtonInput input, string inputKey) {
        return input.InputButton(inputKey) ? 1f : 0f;
    }
    
    private float GetSpeed(MovementProperties movementProperties) {
        return movementProperties.Speed * movementProperties.MultiplierSpeed * runningSpeed;
    }
	
	private float MultiplierSpeedCalculator(IButtonInput input) {
        if(input.InputButton("Run")) {
            running = true;
            return 1.5f;
        }
        running = false;
        return 1f;
    }
}
