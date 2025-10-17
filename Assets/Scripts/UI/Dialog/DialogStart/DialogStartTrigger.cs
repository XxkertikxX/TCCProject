using UnityEngine;
using Cinemachine;
public class DialogStartTrigger : DialogStartBase
{
    [SerializeField] private bool isInteractable;
    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            if (!isInteractable)
            {
                StartDialog();
                GetComponent<Collider2D>().enabled = false;
            }
            else
            {
                if (InputCatalyst.input.InputButtonDown("Interact"))
                {
                    StartDialog();
                    GetComponent<Collider2D>().enabled = false;
                }
            }
        }
    }
}