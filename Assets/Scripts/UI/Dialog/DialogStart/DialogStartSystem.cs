
using UnityEngine;

public class DialogStartSystem : MonoBehaviour
{	
    [SerializeField] private DialogStartBase dialogStart;

    void OnEnable() {
        dialogStart.OnDialogOpen += SetupDialog;
    }

    void OnDisable() {
        dialogStart.OnDialogOpen -= SetupDialog;
    }

    private void SetupDialog() {
        IDialogWriter dialogWriter = GetComponent<IDialogWriter>();
        string[] texts = GetComponent<TextActionString>().TextAction();
        dialogWriter.Constructor(texts);
        dialogWriter.StartLine();
    }
}