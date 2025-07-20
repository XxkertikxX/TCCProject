using UnityEngine;

public class DialogUI : MonoBehaviour
{
    [SerializeField] private GameObject screenDialog;
    [SerializeField] private GameObject screenHUD;

    void OnEnable() {
        DialogManager.OnDialogOpen += SetupDialog;
        DialogManager.OnDialogClose += SetupEndDialog;
    }

    void OnDisable() {
        DialogManager.OnDialogOpen -= SetupDialog;
        DialogManager.OnDialogClose -= SetupEndDialog;
    }
    
    private void SetupDialog() {
        screenDialog.SetActive(true);
        screenHUD.SetActive(false);
    }
    
    private void SetupEndDialog(){
        screenDialog.SetActive(false);
        screenHUD.SetActive(true);
    }
}
