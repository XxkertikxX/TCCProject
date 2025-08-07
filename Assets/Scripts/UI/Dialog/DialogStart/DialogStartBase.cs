using UnityEngine;
using System;

public class DialogStartBase : MonoBehaviour {
    public event Action OnDialogOpen;

    public void StartDialog() {
        OnDialogOpen?.Invoke();
        DialogManager.OpenDialog();
    }
}