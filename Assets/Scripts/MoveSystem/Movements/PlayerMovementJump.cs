using UnityEngine;

public class PlayerMovementJump : MonoBehaviour, IMovement
{        
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask ground;

    private bool requestJump = false;

    public void Move(Rigidbody2D rb, MovementProperties movementProperties) {
        rb.AddForce(Vector2.up * GetJumpForce(movementProperties), ForceMode2D.Impulse);
        requestJump = false;
    }

    public bool Apply(IButtonInput input) {
        bool keyPressed = input.InputButtonDown("Jump");
        bool isGrounded  = Physics2D.Raycast(groundCheck.position, Vector2.down, 0.1f, ground);

        if(keyPressed) {
            requestJump = true;
        }

        return isGrounded && requestJump;
    }

    private float GetJumpForce(MovementProperties movementProperties) {
        return movementProperties.JumpForce * movementProperties.MultiplierJumpForce;
    }
}