using UnityEngine;

public class SaveUpdate : MonoBehaviour {
    static public int Level;

    void Update() {
        if(InputCatalyst.input.InputButtonDown("Save")) {
            SaveSystem saveSystem = new SaveSystem();
            saveSystem.Save(Level);
        }
    }
}
