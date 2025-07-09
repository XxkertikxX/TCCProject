using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    [SerializeField] private ScrDialog dialog;
    [SerializeField] private bool needsInteract;
    [SerializeField] private GameObject promptPressE;

    private PlayerMovement playerMovement;
    private bool inDialog = false;

    void Awake() {
        playerMovement = PlayerMovement.InstancePlayerMovement;
    }

    void OnEnable() {
        DialogManager.OnDialogOpen += setupOpenDialog;
        DialogManager.OnDialogClose += setupCloseDialog;
    }

    void OnDisable() {
        DialogManager.OnDialogOpen -= setupOpenDialog;
        DialogManager.OnDialogClose -= setupCloseDialog;
    }

    void OnTriggerStay2D(Collider2D collision) {
        if (collision.CompareTag("Player") && inDialog == false) {
            mustActiveDialog();
        }
    }

    void OnTriggerExit2D(Collider2D collision) {
        if (!collision.CompareTag("Player")) return;

        if (promptPressE != null) {
            promptPressE.SetActive(false);
        }
    }

    private void mustActiveDialog() {
        if (needsInteract) {
            promptActiveDialogue();
        }
        else {
            if (isGrounded()) {
                activeDialog();
            }
        }
    }

    private void promptActiveDialogue() {
        promptPressE.SetActive(isGrounded());

        if (Input.GetKeyDown(KeyCode.E) && isGrounded()) {
            activeDialog();
        }
    }

    private void activeDialog() {
        if (promptPressE != null) {
            promptPressE.SetActive(false);
        }
    }

    private bool isGrounded() {
        return playerMovement.IsGrounded;
    }
    
    private void setupOpenDialog(){
        inDialog = true;
        playerMovement.enabled = false;
        DialogManager.InstanceDialogManager.Dialogs = dialog.LineDialog;
        DialogManager.InstanceDialogManager.openDialog();
    }
    
    private void setupCloseDialog() {
        inDialog = false;
        playerMovement.enabled = true;
    }
}