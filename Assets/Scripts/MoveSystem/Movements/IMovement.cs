using UnityEngine;

public interface IMovement {
    public void Move(Rigidbody2D rb);
    public bool Apply(IButtonInput input);
}