using UnityEngine;
using System;

public class DialogManager : MonoBehaviour
{
    public static event Action OnDialogOpen;
    public static event Action OnDialogClose;
    public static DialogManager Instance { get; private set; }

    public LineDialog[] Dialogs;

    void Awake() {
        Instance = this;
    }

    public void OpenDialog(ScrDialog dialog) {
        Dialogs = dialog.LineDialog;
        OnDialogOpen?.Invoke();
    }
    
    public void CloseDialog() {
        OnDialogClose?.Invoke();
    }
}