using UnityEngine;

public class PlayerMovementJump : MonoBehaviour, IMovement
{
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask ground;

    [Header("Hold jump settings")]
    [SerializeField] private float maxHoldTime = 0.30f;

    private bool requestJump = false;
    private bool isJumping = false;
    private float holdTimeRemaining = 0f;
    private bool holdingJump = false;

    [HideInInspector] public bool _holdingJump { get { return holdingJump; } set { holdingJump = value; } }

    public void Move(Rigidbody2D rb, MovementProperties movementProperties)
    {
        //AnimationSrc.Play("Jumping");
        if (requestJump)
        {
            float jumpVelocity = movementProperties.JumpForce * movementProperties.MultiplierJumpForce;
            rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
            requestJump = false;
            isJumping = true;
            holdTimeRemaining = maxHoldTime;
            return;
        }

        if (isJumping && holdingJump && holdTimeRemaining > 0f && rb.velocity.y > 0f)
        {
            float jumpVelocity = movementProperties.JumpForce * movementProperties.MultiplierJumpForce;
            rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
            holdTimeRemaining -= Time.fixedDeltaTime;
        }

        if (rb.velocity.y <= 0f && isJumping)
        {
            isJumping = false;
        }
    }

    public bool Apply(IButtonInput input)
    {
        bool keyPressed;
        bool keyHeld;

        try { keyPressed = input.InputButtonDown("Jump"); }
        catch { keyPressed = false; }
        try { keyHeld = input.InputButton("Jump"); }
        catch { keyHeld = keyPressed; }

        bool isGrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, 0.1f, ground);

        if (keyPressed && isGrounded)
        {
            requestJump = true;
        }

        holdingJump = keyHeld;

        if (isJumping && !holdingJump)
        {
            isJumping = false;
            holdTimeRemaining = 0f;
        }

        if (isGrounded && requestJump) return true;
        if (isJumping && holdingJump && holdTimeRemaining > 0f) return true;
        return false;
    }

    public bool grounded()
    {
        return Physics2D.Raycast(groundCheck.position, Vector2.down, 0.1f, ground);
    }
}