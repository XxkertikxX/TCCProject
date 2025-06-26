using UnityEngine;

public class MainMenuButtons : MonoBehaviour
{
    public void StartGame() {

    }

    public void OpenMenu(GameObject menu) {
        menu.SetActive(true);
    }

    public void CloseMenu(GameObject menu) {
        menu.SetActive(false);
    }

    public void ExitGame() {
        Application.Quit();
    }
}
