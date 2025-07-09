using UnityEngine;

public class PlayerCheckpoint : MonoBehaviour
{
    private Vector3 lastCheckpointPosition;

    void Start() {
        lastCheckpointPosition = transform.position;
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Checkpoint")) {
            lastCheckpointPosition = transform.position;
        }
        else if (collision.CompareTag("Hole")) {
            transform.position = lastCheckpointPosition;
        }
    }
}