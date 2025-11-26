using UnityEngine;
using Cinemachine;
public class DialogStartTrigger : DialogStartBase
{
    [SerializeField] private bool isInteractable;
    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            StartDialog(); //essa
            GetComponent<Collider2D>().enabled = false;
        }
    }
}