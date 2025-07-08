using UnityEngine;
using UnityEngine.UI;

public class SetupBattle : MonoBehaviour
{
    [SerializeField] GameObject UI;
    [SerializeField] ScrDialog scrDialog;


    private void OnEnable() {
        DialogManager.onDialogClose += ActiveUI;
    }

    void Start() {
        dialogManager().dialogs = scrDialog.lineDialog;
        dialogManager().openDialog();
        StatesUIButton(false);
    }
    
    DialogManager dialogManager() {
        return DialogManager.dialogManager;
    }
    
    private void ActiveUI() {
        UI.SetActive(true);
        StatesUIButton(true);
    }

    private void StatesUIButton(bool state) {
        Button[] botoes = FindObjectsOfType<Button>();
        foreach (Button b in botoes) {
            b.interactable = state;
        }
    }

    private void OnDisable() {
        DialogManager.onDialogClose -= ActiveUI;
    }
}