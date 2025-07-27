using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementJump : PlayerMovementBase, IVerticalMovement
{    
    private float jumpForce = 10f;

    public void MoveY() {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
