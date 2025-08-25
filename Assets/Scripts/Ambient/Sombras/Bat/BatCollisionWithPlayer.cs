using UnityEngine;

public class BatCollisionWithPlayer : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player")) {
            
        }
    }
}