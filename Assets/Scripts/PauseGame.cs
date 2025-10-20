using UnityEngine;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [HideInInspector] public bool Paused = false;
    private void Update() {
        if (InputCatalyst.input.InputButtonDown("Menu")) {
            pauseMenu.SetActive(checkGamePause());
        }
    }

    private bool checkGamePause() {
        if (Paused) {
            Paused = false;
            Time.timeScale = 1.0f;
            return false;
        }
        else {
            Paused = true;
            Time.timeScale = 0;
            return true;
        }
    }
}
