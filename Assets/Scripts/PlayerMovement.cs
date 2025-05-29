using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    float x;
    [SerializeField] float speed;
    [SerializeField] float jumpForce;

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

    void Jump(){
        if(Input.GetButtonDown("Jump")) {
            rb.AddForce(new Vector2(0, jumpForce));
        }
    }
}