using UnityEngine;

public class ApplyDialogSetups : MonoBehaviour
{
	[SerializeField] private DialogStartBase dialogBase;
    private IDialogSetup[] dialogSetup;
	private bool isDialog;

    void Awake() {
        dialogSetup = GetComponents<IDialogSetup>();
		dialogBase = GetComponent<DialogStartBase>();
    }

    void OnEnable() {
        dialogBase.OnDialogOpen += SetupOpenDialog;
        DialogManager.OnDialogClose += SetupCloseDialog;
    }

    void OnDisable() {
        dialogBase.OnDialogOpen -= SetupOpenDialog;
        DialogManager.OnDialogClose -= SetupCloseDialog;
    }
    
    private void SetupOpenDialog() {
        SetupAllOpenDialog();
    }
    
    private void SetupCloseDialog() {
        SetupAllCloseDialog();
    }
    
    private void SetupAllOpenDialog() {
		isDialog = true;
        foreach (var setup in dialogSetup) {
            setup.SetupOpenDialog();
        }
    }
    
    private void SetupAllCloseDialog() {
		if(isDialog == false) return;
        foreach (var setup in dialogSetup) {
            setup.SetupCloseDialog();
        }
		isDialog = false;
    }
}