using UnityEngine;

public class PlayerMovementJump : MonoBehaviour, IMovement
{        
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask ground;

    private float jumpForce = 10f;

    public void Move(Rigidbody2D rb) {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    public bool Apply(IButtonInput input) {
        bool keyPressed = input.InputButtonDown("Jump"); //essa linha
        bool isGrounded  = Physics2D.Raycast(groundCheck.position, Vector2.down, 0.1f, ground);
        return isGrounded && keyPressed;
    }
}