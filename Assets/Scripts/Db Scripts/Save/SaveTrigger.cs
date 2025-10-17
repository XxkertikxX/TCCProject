using UnityEngine;

public class SaveTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player")) {
            GameObject.FindObjectOfType<SaveLoader>().Load();
        }
    }
}
