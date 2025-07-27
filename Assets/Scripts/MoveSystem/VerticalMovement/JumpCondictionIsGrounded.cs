using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCondictionIsGrounded : MonoBehaviour, IVerticalMovementCondiction
{
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask ground;

    public bool CanMove() {
        return Physics2D.Raycast(groundCheck.position, Vector2.down, 0.05f, ground);
    }
}
