
using UnityEngine;

public class DialogStartSystem : MonoBehaviour
{
	[SerializeField] private IconsSO icons;
	
    [SerializeField] private DialogStartBase dialogStart;

    void OnEnable() {
        dialogStart.OnDialogOpen += SetupDialog;
    }

    void OnDisable() {
        dialogStart.OnDialogOpen -= SetupDialog;
    }

    private void SetupDialog() {
        CatalystDialog.Dialog = GetComponent<TextActionString>().TextAction();
		CatalystDialog.Icons = icons.IconsCharacter;
        CatalystDialog.Writer = GetComponent<IDialogWriter>();
    }
}