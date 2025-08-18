using UnityEngine;

public interface IMovement {
    public void Move(Rigidbody2D rb, MovementProperties movementProperties);
    public bool Apply(IButtonInput input);
}