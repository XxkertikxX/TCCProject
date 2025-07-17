using UnityEngine;
using UnityEngine.UI;

public class DialogInterfaceBase : MonoBehaviour
{
    [SerializeField] protected Text textSpeak;
    protected LineDialog[] dialogs;
    protected int index;

    void OnEnable() {
        DialogManager.OnDialogOpen += Setup;
    }

    void OnDisable() {
        DialogManager.OnDialogOpen -= Setup;
    }
    
    private void Setup(){
        index = 0;
        dialogs = DialogManager.InstanceDialogManager.dialogs;
    }
}
