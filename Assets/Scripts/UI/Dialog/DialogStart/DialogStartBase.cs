using UnityEngine;

public abstract class DialogStartBase : MonoBehaviour
{
    [SerializeField] private ScrDialog dialog;
    
    void OnEnable() {
        DialogManager.OnDialogOpen += SetupOpenDialog;
        DialogManager.OnDialogClose += SetupCloseDialog;
    }

    void OnDisable() {
        DialogManager.OnDialogOpen -= SetupOpenDialog;
        DialogManager.OnDialogClose -= SetupCloseDialog;
    }
    
    protected void StartDialog() {
        DialogManager.InstanceDialogManager.OpenDialog(dialog);
    }

    protected abstract void SetupOpenDialog();
    protected abstract void SetupCloseDialog();
}