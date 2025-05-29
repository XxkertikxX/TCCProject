using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    float x;
    [SerializeField] float speed;
    [SerializeField] float jumpForce;

    [SerializeField] Transform GroundCheck;
    [SerializeField] LayerMask Ground;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        rb.velocity = new Vector2(x, rb.velocity.y).normalized * speed;
    }

    void Update() {
        InputDirectionMovement();
        Jump();
    }

    void InputDirectionMovement() {
        x = Input.GetAxisRaw("Horizontal");
    }

    void Jump() {
        bool isGrounded = Physics2D.Raycast(GroundCheck.position, Vector2.down, 0.1f, Ground);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            rb.AddForce(Vector2.up * jumpForce);
        }
    }
}