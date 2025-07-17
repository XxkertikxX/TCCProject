using UnityEngine;
using UnityEngine.UI;

public class SetupBattle : DialogStartBase
{
    [SerializeField] private GameObject UI;

    void OnEnable() {
        DialogManager.OnDialogOpen += SetupOpenDialog;
        DialogManager.OnDialogClose += SetupCloseDialog;
    }

    void OnDisable() {
        DialogManager.OnDialogOpen -= SetupOpenDialog;
        DialogManager.OnDialogClose -= SetupCloseDialog;
    }

    void Start(){
        StartDialog();
    }
    
    protected override void SetupOpenDialog() {
        StatesUIButton(false);
        UI.SetActive(false);
    }

    protected override void SetupCloseDialog() {
        StatesUIButton(true);
        UI.SetActive(true);
    }
    
    private void StatesUIButton(bool state) {
        Button[] botoes = FindObjectsOfType<Button>();
        foreach (Button b in botoes) {
            b.interactable = state;
        }
    }
}