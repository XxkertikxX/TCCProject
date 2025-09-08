using UnityEngine;

public class DialogWriterSystem : MonoBehaviour
{
    private IDialogWriter dialogWriter;
    private string[] dialogs;

    void OnEnable() {
        DialogManager.OnDialogOpen += Setup;
    }

    void OnDisable() {
        DialogManager.OnDialogOpen -= Setup;
    }

    private void Setup() {
        dialogWriter = CatalystDialog.Writer;
        dialogs = CatalystDialog.Dialog;
        dialogWriter.Constructor(dialogs);
        dialogWriter.StartLine();
    }
}