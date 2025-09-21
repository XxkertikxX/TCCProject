using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementSystem : MonoBehaviour
{
    private List<IMovement> movements;
    private List<bool> mustMovement;

    private Rigidbody2D rb;
    private MovementProperties movementProperties;
    private AnimationSrc anim;

    void OnDisable() {
        rb.velocity = Vector2.zero;
    }

    void Awake() {
        movementProperties = gameObject.AddComponent<MovementProperties>();
        movements = GetComponents<IMovement>().ToList();
        mustMovement = Enumerable.Repeat(false, movements.Count).ToList();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<AnimationSrc>();
    }

    void Update() {
        for(int i = 0; i < movements.Count; i++) {
            mustMovement[i] = movements[i].Apply(InputCatalyst.input);
            anim.UpdateAnimation();
        }
    }

    void FixedUpdate() {
        for(int i = 0; i < movements.Count; i++) {
            if(mustMovement[i]) {
                movements[i].Move(rb, movementProperties);
            }
        }
    }
}