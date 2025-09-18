using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{
    bool isFull;
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

    public void Fullscreen()
    {
        isFull = Screen.fullScreen;
        isFullScreen();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    public void PlayButtonSound()
    {
        GameAudioManager.PlaySound(SoundTypes.ClickButton);
    }

    public void VisualDemosntration(Image activated)
    {
        activated.gameObject.SetActive(isFullScreen());
    }

    private bool isFullScreen()
    {
        if (isFull)
            return Screen.fullScreen = false;
        else
            return Screen.fullScreen = true;
    }
}
