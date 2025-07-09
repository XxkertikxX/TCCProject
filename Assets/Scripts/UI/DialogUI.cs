using UnityEngine;

public class DialogUI : MonoBehaviour
{
    [SerializeField] private GameObject screenDialog;
    [SerializeField] private GameObject screenHUD;

    void OnEnable() {
        DialogManager.OnDialogOpen += setupDialog;
        DialogManager.OnDialogClose += setupEndDialog;
    }

    void OnDisable() {
        DialogManager.OnDialogOpen -= setupDialog;
        DialogManager.OnDialogClose -= setupEndDialog;
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
}
