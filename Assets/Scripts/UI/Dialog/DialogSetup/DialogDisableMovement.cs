using UnityEngine;

public class DialogDisableMovement : MonoBehaviour, IDialogSetup
{
    [SerializeField] private PlayerMovementSystem playerMovement;

    void Start() {
        //playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementSystem>();
    }

    public void SetupOpenDialog() {
        playerMovement.enabled = false; //nao encontrou
    }

    public void SetupCloseDialog() {
        playerMovement.enabled = true;
    }
}