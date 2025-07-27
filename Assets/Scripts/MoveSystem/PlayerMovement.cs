using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool IsGrounded;

    private IButtonInput inputButton;

    private float speed = 5f;
    private float jumpForce = 10f;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask ground;

    private Rigidbody2D rb;
    private float x;

    void OnDisable() {
        rb.velocity = Vector2.zero;
    }

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        inputButton = GetComponent<IButtonInput>();
    }

    void FixedUpdate() {
        rb.velocity = new Vector2(x * speed, rb.velocity.y);
    }

    void Update() {
        InputDirectionMovement();
        Jump();
    }

    private void InputDirectionMovement() {
        x = 0;
        x -= GetDirectionX("Left");
        x += GetDirectionX("Right");
    }

    private float GetDirectionX(string inputKey) {
        return inputButton.InputButton(inputKey) ? 1f : 0f;
    }
    
    private void Jump() {
        IsGrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, 0.05f, ground);
        if (inputButton.InputButtonDown("Jump") && IsGrounded) {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
