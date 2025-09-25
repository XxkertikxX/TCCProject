using UnityEngine;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    bool paused = false;
    private void Update()
    {
        if (InputCatalyst.input.InputButtonDown("Menu"))
        {
            pauseMenu.SetActive(checkGamePause());
        }
    }

    private bool checkGamePause()
    {
        if (paused)
        {
            paused = false;
            Time.timeScale = 1.0f;
            return false;
        }
        else
        {
            paused = true;
            Time.timeScale = 0;
            return true;
        }
    }
}
