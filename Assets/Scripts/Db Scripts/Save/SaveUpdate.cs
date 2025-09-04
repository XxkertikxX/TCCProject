using UnityEngine;

public class SaveUpdate : MonoBehaviour {
    void Update() {
        if(InputCatalyst.input.InputButtonDown("Save")) {
            SaveSystem saveSystem = new SaveSystem();
            saveSystem.Save();
        }
    }
}
