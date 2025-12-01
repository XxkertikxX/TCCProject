using UnityEngine;

public class DialogEnableUI : MonoBehaviour, IDialogSetup
{
    [SerializeField] private GameObject screenDialog;
    [SerializeField] private GameObject screenHUD;
    public bool active = true;

    public void SetupOpenDialog() {
        screenDialog.SetActive(true);
        screenHUD.SetActive(false);
    }
    
    public void SetupCloseDialog(){
		Debug.Log("Active =" + active);
        screenDialog.SetActive(active);
        screenHUD.SetActive(!active);
    }
}