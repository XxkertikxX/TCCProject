using UnityEngine;
using System;

public abstract class DialogStartBase : MonoBehaviour {
    public event Action OnDialogOpen;

    protected void StartDialog() {
        OnDialogOpen?.Invoke();
        DialogManager.OpenDialog();
    }
}