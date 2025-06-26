using UnityEngine;

public class PlayerCheckpoint : MonoBehaviour
{
    private Vector3 lastCheckpointPosition;
    public GameObject playerGO;

    private void Start()
    {
        lastCheckpointPosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            lastCheckpointPosition = transform.position;
        }
        else if (other.CompareTag("Hole"))
        {
            playerGO.transform.position = lastCheckpointPosition;
        }
    }
}