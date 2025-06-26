using UnityEngine;

public class PlayerCheckpoint : MonoBehaviour
{
    private Vector3 lastCheckpointPosition;

    private void Start()
    {
        lastCheckpointPosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            lastCheckpointPosition = transform.position;
        }
        else if (other.CompareTag("Hole"))
        {
            transform.position = lastCheckpointPosition;
        }
    }
}