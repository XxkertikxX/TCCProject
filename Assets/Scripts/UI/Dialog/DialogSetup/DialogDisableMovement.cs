using UnityEngine;

public class DialogDisableMovement : MonoBehaviour, IDialogSetup
{
    private PlayerMovementSystem playerMovement;

    void Start() {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementSystem>();
    }

    public void SetupOpenDialog() {
        playerMovement.enabled = false;
    }

    public void SetupCloseDialog() {
        playerMovement.enabled = true;
    }
}