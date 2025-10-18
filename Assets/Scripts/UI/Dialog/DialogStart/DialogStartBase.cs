using UnityEngine;
using System;

public abstract class DialogStartBase : MonoBehaviour {
    public event Action OnDialogOpen;

    public void StartDialog() {
        OnDialogOpen?.Invoke();
        DialogManager.OpenDialog(); //essa
    }
}