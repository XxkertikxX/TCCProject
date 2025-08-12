using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideScr : MonoBehaviour, IEnviromentProperty
{
    public bool hide = false;
    public IEnumerator ApplyEffect(Rigidbody2D targetRB)
    {
        yield return null;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hide = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hide = false;
        }
    }
}