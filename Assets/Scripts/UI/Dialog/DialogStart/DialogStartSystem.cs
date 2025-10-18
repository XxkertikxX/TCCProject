
using UnityEngine;

[RequireComponent(typeof(DialogStartBase))]
[RequireComponent(typeof(ApplyDialogSetups))]
[RequireComponent(typeof(IDialogWriter))]

public class DialogStartSystem : MonoBehaviour
{	
    [SerializeField] private DialogStartBase dialogStart;
    [SerializeField] private TextActionString textAction;

    void OnEnable() {
		var battleText = GameObject.FindObjectOfType<BattleApplyConfig>()?.battleConfigSO.Text;
		if(battleText != null) {
			textAction = battleText;
		}
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