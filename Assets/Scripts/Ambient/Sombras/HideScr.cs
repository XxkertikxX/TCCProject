using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideScr : MonoBehaviour
{
    private bool hide = false;

    private IEnumerator ApplyEffect() {
        yield return null;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            hide = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            hide = false;
        }
    }
}