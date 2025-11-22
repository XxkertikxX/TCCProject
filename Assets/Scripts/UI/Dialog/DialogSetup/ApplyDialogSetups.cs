using UnityEngine;

public class ApplyDialogSetups : MonoBehaviour
{
    private IDialogSetup[] dialogSetup;

    void Awake() {
        dialogSetup = GetComponents<IDialogSetup>();
    }

    void OnEnable() {
        DialogManager.OnDialogOpen += SetupOpenDialog;
        DialogManager.OnDialogClose += SetupCloseDialog;
    }

    void OnDisable() {
        DialogManager.OnDialogOpen -= SetupOpenDialog;
        DialogManager.OnDialogClose -= SetupCloseDialog;
    }
    
    private void SetupOpenDialog() {
        SetupAllOpenDialog();
    }
    
    private void SetupCloseDialog() {
        SetupAllCloseDialog();
    }
    
    private void SetupAllOpenDialog() {
        foreach (var setup in dialogSetup) {
            setup.SetupOpenDialog();
        }
    }
    
    private void SetupAllCloseDialog() {
        foreach (var setup in dialogSetup) {
            setup.SetupCloseDialog();
        }
    }
}