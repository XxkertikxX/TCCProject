using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementWalk : PlayerMovementBase, IHorizontalMovement
{    
    private float speed = 5f;

    public void MoveX(){
        rb.velocity = new Vector2(InputDirectionMovement() * speed, rb.velocity.y);
    }

    private float InputDirectionMovement() {
        float inputDirection = 0;
        inputDirection -= GetDirectionX("Left");
        inputDirection += GetDirectionX("Right");
        return inputDirection;
    }

    private float GetDirectionX(string inputKey) {
        return inputButton.InputButton(inputKey) ? 1f : 0f;
    }
}
