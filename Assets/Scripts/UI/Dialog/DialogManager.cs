using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DialogManager : MonoBehaviour
{
    public static event Action OnDialogOpen;
    public static event Action OnDialogClose;
    public static DialogManager InstanceDialogManager { get; private set; }

    public LineDialog[] dialogs;

    void Awake() {
        InstanceDialogManager = this;
    }

    public void OpenDialog(ScrDialog dialog) {
        dialogs = dialog.LineDialog;
        OnDialogOpen?.Invoke();
    }
    
    public void CloseDialog() {
        OnDialogClose?.Invoke();
    }
}