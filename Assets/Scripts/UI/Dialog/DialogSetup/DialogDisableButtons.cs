using UnityEngine;
using UnityEngine.UI;

public class DialogDisableButtons : MonoBehaviour, IDialogSetup
{
    private Button[] buttons;

    void Awake() {
        buttons = FindObjectsOfType<Button>();
    }
    
    public void SetupOpenDialog() {
        StatesUIButton(false);
    }

    public void SetupCloseDialog() {
        StatesUIButton(true);
    }
    
    private void StatesUIButton(bool state) {
		foreach (var b in buttons) {
			if (b != null)
				b.interactable = state;
		}
    }
}
