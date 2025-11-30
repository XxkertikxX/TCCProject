using UnityEngine;

public class SaveUpdate : MonoBehaviour {

    private bool checkUnlocked;
    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player")) {
            SaveSystem saveSystem = new SaveSystem();
            saveSystem.Save();
            if (!checkUnlocked)
            {
                checkUnlocked = true;
                //GameObject.FindObjectOfType<EnteringNewArea>().MakeTextAppear("Checkpoint desbloqueado!");
            }
        }
    }
}
