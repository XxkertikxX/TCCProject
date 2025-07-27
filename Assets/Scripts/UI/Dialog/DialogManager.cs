using UnityEngine;
using System;

public class DialogManager : MonoBehaviour
{
    static public event Action OnDialogOpen;
    static public event Action OnDialogClose;

    static public void OpenDialog() {
        OnDialogOpen?.Invoke();
    }
    
    static public void CloseDialog() {
        OnDialogClose?.Invoke();
    }
}