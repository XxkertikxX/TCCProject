using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DialogManager : MonoBehaviour
{
    public static event Action OnDialogOpen;
    public static event Action OnDialogClose;
    public static DialogManager InstanceDialogManager { get; private set; }

    public LineDialog[] Dialogs;

    void Awake() {
        InstanceDialogManager = this;
    }

    public void OpenDialog(ScrDialog dialog) {
        Dialogs = dialog.LineDialog;
        OnDialogOpen?.Invoke();
    }
    
    public void CloseDialog() {
        OnDialogClose?.Invoke();
    }
}