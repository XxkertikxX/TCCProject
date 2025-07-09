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
        InstanceDialogManager().Dialogs = scrDialog.LineDialog;
        InstanceDialogManager().OpenDialog();
        StatesUIButton(false);
    }
    
    private DialogManager InstanceDialogManager() {
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