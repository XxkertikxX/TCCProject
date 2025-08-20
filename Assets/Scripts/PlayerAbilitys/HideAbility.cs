using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideAbility : IAbility
{
    private bool hide = false;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("HideWall")) {
            hide = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("HideWall")) {
            hide = false;
        }
    }

    //public 
}
