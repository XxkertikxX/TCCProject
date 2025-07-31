using UnityEngine;
using UnityEngine.UI;
using System;

public class DialogWriterSystem : MonoBehaviour
{
    static public event Action OnNextLine;

    private IDialogWriter dialogWriter;
    private LineDialog[] dialogs;
    private int index;

    void OnEnable() {
        DialogManager.OnDialogOpen += Setup;
        DialogManager.OnDialogClose += EndSetup;
    }

    void OnDisable() {
        DialogManager.OnDialogOpen -= Setup;
        DialogManager.OnDialogClose -= EndSetup;
    }

    private void Setup() {
        dialogs = CatalystDialog.Dialog;
        dialogWriter.StartLine();
    }
    
    private void EndSetup() {

    }
}