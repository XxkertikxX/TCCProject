using UnityEngine;

public abstract class DialogStartBase : MonoBehaviour
{
    [SerializeField] private ScrDialog dialog;
    
    protected void StartDialog() {
        DialogManager.InstanceDialogManager.OpenDialog(dialog);
    }

    protected abstract void SetupOpenDialog();
    protected abstract void SetupCloseDialog();
}