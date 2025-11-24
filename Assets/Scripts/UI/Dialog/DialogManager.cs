using System;
using UnityEngine;
public class DialogManager
{
    static public event Action OnDialogOpen;
    static public event Action OnDialogClose;
	
	static public bool OnDialog;

    static public void OpenDialog() {
        OnDialogOpen?.Invoke();
		OnDialog = true;
    }
    
    static public void CloseDialog() {
        OnDialogClose?.Invoke();
		OnDialog = false;
    }
}