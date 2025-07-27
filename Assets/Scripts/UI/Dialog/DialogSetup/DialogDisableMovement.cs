using UnityEngine;

public class DialogDisableMovement : MonoBehaviour, IDialogSetup
{
    private PlayerMovement playerMovement;

    void Start() {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    public void SetupOpenDialog() {
        playerMovement.enabled = false;
    }

    public void SetupCloseDialog() {
        playerMovement.enabled = true;
    }
}