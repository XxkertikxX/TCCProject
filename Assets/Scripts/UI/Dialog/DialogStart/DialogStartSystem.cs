using UnityEngine;

public class DialogStartSystem : MonoBehaviour
{
    [SerializeField] private ScrDialog dialog;
    [SerializeField] private DialogStartBase dialogStart;

    void OnEnable() {
        dialogStart.OnDialogOpen += SetupDialog;
    }

    void OnDisable() {
        dialogStart.OnDialogOpen -= SetupDialog;
    }

    private void SetupDialog() {
        CatalystDialog.Dialog = dialog.LineDialog;
        CatalystDialog.Writer = GetComponent<IDialogWriter>();
    }
}