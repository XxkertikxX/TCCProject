using UnityEngine;

public abstract class DialogStartBase : MonoBehaviour
{
    [SerializeField] private ScrDialog dialog;

    protected void StartDialog() {
        DialogManager.OpenDialog();
        CatalystDialog.Dialog = dialog.LineDialog;
    }
}
