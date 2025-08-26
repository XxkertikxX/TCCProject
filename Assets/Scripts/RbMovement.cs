using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RbMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Awake() => rb = GetComponent<Rigidbody2D>();

    public void Move(Vector2 direction, float speed) {
        rb.velocity = direction.normalized * speed;
    }

    public void Stop() => rb.velocity = Vector2.zero;
}