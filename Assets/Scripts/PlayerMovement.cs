using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    static public PlayerMovement playerMovement;
    public bool isGrounded;

    Rigidbody2D rb;

    float x;
    [SerializeField] float speed;
    [SerializeField] float jumpForce;

    [SerializeField] Transform GroundCheck;
    [SerializeField] LayerMask Ground;

    void Start() {
        playerMovement = gameObject.GetComponent<PlayerMovement>();
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

    void InputDirectionMovement() {
        x = 0;
        DirectionX(Bindings.bindings["Left"], -1);
        DirectionX(Bindings.bindings["Right"], 1);
    }

    void DirectionX(KeyCode key, int direction) {
        if (Input.GetKey(key)) {
            x += direction;
        }
    }

    void Jump() {
        isGrounded = Physics2D.Raycast(GroundCheck.position, Vector2.down, 0.1f, Ground);
        if (Input.GetKeyDown(Bindings.bindings["Jump"]) && isGrounded) {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void OnDisable() {
        rb.velocity = new Vector2(0, 0);
    }
}