using System;

public class DialogManager
{
    static public event Action OnDialogOpen;
    static public event Action OnDialogClose;

    static public void OpenDialog() {
        OnDialogOpen?.Invoke(); //essa
    }
    
    static public void CloseDialog() {
        OnDialogClose?.Invoke();
    }
}