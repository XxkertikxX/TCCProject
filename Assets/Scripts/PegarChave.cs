using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegarChave : MonoBehaviour
{
    static public bool HaveKey;
    void private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Key")) {
            Destroy(collision.gameObject);
            HaveKey = true;
        }
    }
}