using UnityEngine;

public class SaveEnable : MonoBehaviour {
    void Awake() {
        SaveSystem saveSystem = new SaveSystem();
        saveSystem.Save();
    }
}
