using UnityEngine;
using UnityEngine.UI;

public class SetupBattle : MonoBehaviour
{
    [SerializeField] private GameObject UI;
    [SerializeField] private ScrDialog scrDialog;


    void OnEnable() {
        DialogManager.OnDialogClose += ActiveUI;
    }

    void OnDisable() {
        DialogManager.OnDialogClose -= ActiveUI;
    }
    
    void Start() {
        dialogManager().Dialogs = scrDialog.LineDialog;
        dialogManager().openDialog();
        StatesUIButton(false);
    }
    
    private DialogManager dialogManager() {
        return DialogManager.InstanceDialogManager;
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
}