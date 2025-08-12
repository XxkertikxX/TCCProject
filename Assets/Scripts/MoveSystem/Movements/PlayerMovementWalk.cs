using UnityEngine;

public class PlayerMovementWalk : MonoBehaviour, IMovement
{    
    public float speed = 5f;
    private float inputDirection;

    public void Move(Rigidbody2D rb) {
        rb.velocity = new Vector2(inputDirection * speed, rb.velocity.y);
    }

    public bool Apply(IButtonInput input) {
        InputDirectionCalculator(input);
        return true;
    }

    private void InputDirectionCalculator(IButtonInput input) {
        inputDirection = 0;
        inputDirection -= GetDirectionX(input, "Left");
        inputDirection += GetDirectionX(input, "Right");
    }

    private float GetDirectionX(IButtonInput input, string inputKey) {
        return input.InputButton(inputKey) ? 1f : 0f;
    }
}
