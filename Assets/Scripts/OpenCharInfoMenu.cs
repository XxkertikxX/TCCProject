using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenCharInfoMenu : MonoBehaviour
{
    [SerializeField] private GameObject InfoMenu;
    private bool isOpened = false;
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Battle")
            return;

        if (InputCatalyst.input.InputButtonDown("Tab") && !GetComponent<PauseGame>().Paused)
            ShowInfoMenu();
    }

    private void ShowInfoMenu()
    {
        if (!isOpened)
        {
            isOpened = true;
            InfoMenu.SetActive(true);
        }
        else
        {
            isOpened = false;
            InfoMenu.SetActive(false);
        }
    }
}
