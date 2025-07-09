using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    static public PlayerMovement InstancePlayerMovement;
    public bool IsGrounded;

    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask ground;
    
    private Rigidbody2D rb;

    private float x;

    void OnDisable() {
        rb.velocity = new Vector2(0, 0);
    }
    
    void Start() {
        InstancePlayerMovement = gameObject.GetComponent<PlayerMovement>();
        Bindings.UpdateBindings();
        rb = GetComponent<Rigidbody2D>();
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
        DirectionX(Bindings.BindingsDic["Left"], -1);
        DirectionX(Bindings.BindingsDic["Right"], 1);
    }

    private void DirectionX(KeyCode key, int direction) {
        if (Input.GetKey(key)) {
            x += direction;
        }
    }

    private void Jump() {
        IsGrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, 0.1f, ground);
        if (Input.GetKeyDown(Bindings.BindingsDic["Jump"]) && IsGrounded) {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}