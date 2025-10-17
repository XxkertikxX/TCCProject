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

    void OnDisable() {
        rb.velocity = Vector2.zero;
    }

    void Awake() {
        movementProperties = gameObject.AddComponent<MovementProperties>();
        movements = GetComponents<IMovement>().ToList();
        mustMovement = Enumerable.Repeat(false, movements.Count).ToList();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        for(int i = 0; i < movements.Count; i++) {
            mustMovement[i] = movements[i].Apply(InputCatalyst.input);
            //AnimationSrc.instance.UpdateAnimation("a");
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