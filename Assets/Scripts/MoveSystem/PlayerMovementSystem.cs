using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

[RequireComponent(typeof(IMovement))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(IButtonInput))]

public class PlayerMovementSystem : MonoBehaviour
{
    private List<IMovement> movements;

    private Rigidbody2D rb;
    private IButtonInput input;

    void OnDisable() {
        rb.velocity = Vector2.zero;
    }

    void Awake() {
        movements = GetComponents<IMovement>().ToList();
        rb = GetComponent<Rigidbody2D>();
        input = GetComponent<IButtonInput>();
    }

    void FixedUpdate() {
        foreach (var move in movements) {
            if(move.Apply(input)) {
                move.Move(rb);
            }
        }
    }
}