using UnityEngine;

public class SaveUpdate : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player")) {
            SaveSystem saveSystem = new SaveSystem();
            saveSystem.Save();
        }
    }
}
