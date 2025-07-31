using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementSystem : MonoBehaviour
{
    private List<IMovement> movements;

    private Rigidbody2D rb;

    void OnDisable() {
        rb.velocity = Vector2.zero;
    }

    void Awake() {
        movements = GetComponents<IMovement>().ToList();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        foreach (var move in movements) {
            if(move.Apply(InputCatalyst.input)) {
                move.Move(rb);
            }
        }
    }
}