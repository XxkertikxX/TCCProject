using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    [SerializeField] ScrDialog dialog;
    [SerializeField] bool precisaInteragir;
    [SerializeField] GameObject promptApertarE;
    private PlayerMovement playerMovement;
    private bool inDialog = false;
    void Awake() {
        playerMovement = PlayerMovement.playerMovement;
    }

    void OnEnable() {
        DialogManager.onDialogOpen += setupOpenDialog;
        DialogManager.onDialogClose += setupCloseDialog;
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.CompareTag("Player") && inDialog == false) {
            mustActiveDialog();
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (!collision.CompareTag("Player")) return;

        if (promptApertarE != null) {
            promptApertarE.SetActive(false);
        }
    }

    private void mustActiveDialog() {
        if (precisaInteragir) {
            promptActiveDialogue();
        }
        else {
            if (isGrounded()) {
                activeDialog();
            }
        }
    }

    private void promptActiveDialogue() {
        promptApertarE.SetActive(isGrounded());

        if (Input.GetKeyDown(KeyCode.E)) {
            activeDialog();
        }
    }

    private void activeDialog() {
        if (promptApertarE != null) {
            promptApertarE.SetActive(false);
        }
    }

    private void setupActiveDialog() {
        playerMovement.enabled = false;
        DialogManager.dialogManager.dialogs = dialog.lineDialog;
        DialogManager.dialogManager.openDialog();
    }

    private bool isGrounded() {
        return playerMovement.isGrounded;
    }
    
    private void setupOpenDialog(){
        inDialog = true;
    }
    
    private void setupCloseDialog() {
        inDialog = false;
        playerMovement.enabled = true;
    }
    
    void OnDisable() {
        DialogManager.onDialogOpen -= setupOpenDialog;
        DialogManager.onDialogClose -= setupCloseDialog;
    }
}