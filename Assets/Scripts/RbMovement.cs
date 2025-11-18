using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RbMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Awake() => rb = GetComponent<Rigidbody2D>();

    public void Move(Vector2 direction, float speed) {
        rb.velocity = direction.normalized * speed;
    }

    public void Look(Vector3 direction) {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        angle = Mathf.Abs(angle);

        float xRotation = 0f;
        float yRotation = 0f;
        float zRotation = angle;

        if (angle > 90 && angle < 270f) {
            yRotation = 180f;
            xRotation = 180f;
        }
        else if(angle <= 90) {
            yRotation = 180f;
            xRotation = 0f;
        }

        transform.eulerAngles = new Vector3(xRotation, yRotation, zRotation);    
    }


    public void Stop() => rb.velocity = Vector2.zero;

    public void ResetGravityScale() => rb.gravityScale = 0;
}