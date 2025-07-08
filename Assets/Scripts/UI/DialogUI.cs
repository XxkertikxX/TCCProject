using UnityEngine;

public class DialogUI : MonoBehaviour
{
    [SerializeField] GameObject screenDialog;
    [SerializeField] GameObject screenHUD;

    void OnEnable() {
        DialogManager.onDialogOpen += setupDialog;
        DialogManager.onDialogClose += setupEndDialog;
    }

    private void setupDialog() {
        Time.timeScale = 0f;
        screenDialog.SetActive(true);
        screenHUD.SetActive(false);
    }
    
    private void setupEndDialog(){
        Time.timeScale = 1f;
        screenDialog.SetActive(false);
        screenHUD.SetActive(true);
    }

    void OnDisable() {
        DialogManager.onDialogOpen -= setupDialog;
        DialogManager.onDialogClose -= setupEndDialog;
    }
}
