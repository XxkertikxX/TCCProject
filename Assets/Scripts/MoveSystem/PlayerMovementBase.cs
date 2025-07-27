using UnityEngine;

public class PlayerMovementBase : MonoBehaviour
{
    protected IButtonInput inputButton;
    protected Rigidbody2D rb;
    
    void OnEnable() {
        PlayerMovementSystem.OnDisablePlayerMovementSystem += StopMovement;
    }

    void OnDisable() {
        PlayerMovementSystem.OnDisablePlayerMovementSystem -= StopMovement;
    }

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        inputButton = GetComponent<IButtonInput>();
    }

    private void StopMovement() {
        rb.velocity = Vector2.zero;
    }
}
