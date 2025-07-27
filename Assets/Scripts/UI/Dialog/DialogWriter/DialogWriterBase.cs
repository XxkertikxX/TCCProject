using UnityEngine;
using UnityEngine.UI;

public abstract class DialogWriterBase : MonoBehaviour
{
    [SerializeField] protected Text textSpeak;
    protected LineDialog[] dialogs;
    protected int index;

    protected bool dialogStart = false;

    void OnEnable() {
        DialogManager.OnDialogOpen += Setup;
        DialogManager.OnDialogClose += EndSetup;
    }

    void OnDisable() {
        DialogManager.OnDialogOpen -= Setup;
        DialogManager.OnDialogClose -= EndSetup;
    }

    private void Setup() {
        dialogStart = true;
        index = 0;
        StartLine();
    }
    
    private void EndSetup() {
        dialogStart = false;
    }

    protected abstract void StartLine();
}