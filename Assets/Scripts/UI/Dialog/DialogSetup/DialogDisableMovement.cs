using UnityEngine;

public class DialogDisableMovement : MonoBehaviour, IDialogSetup
{
    private PlayerMovement playerMovement;

    void Start() {
        playerMovement = PlayerMovement.InstancePlayerMovement;
    }

    public void SetupOpenDialog() {
        playerMovement.enabled = false;
    }

    public void SetupCloseDialog() {
        playerMovement.enabled = true;
    }
}
