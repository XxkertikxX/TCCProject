using UnityEngine;

public class DialogStartTrigger : DialogStartBase
{
    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            StartDialog();
			GetComponent<Collider2D>().enabled = false;
        }
    }
}