
using UnityEngine;

public class DialogStartSystem : MonoBehaviour
{	
    [SerializeField] private DialogStartBase dialogStart;
    [SerializeField] private TextActionString textAction;

    void OnEnable() {
        dialogStart.OnDialogOpen += SetupDialog;
    }

    void OnDisable() {
        dialogStart.OnDialogOpen -= SetupDialog;
    }

    private void SetupDialog() {
        IDialogWriter dialogWriter = GetComponent<IDialogWriter>();
        string[] texts = textAction.TextAction();
        dialogWriter.Constructor(texts);
        dialogWriter.StartLine();
    }
}