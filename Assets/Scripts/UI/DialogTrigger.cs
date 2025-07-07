using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    private ScrDialog dialog;
    [SerializeField] bool precisaInteragir;
    [SerializeField] GameObject promptApertarE;
    private PlayerMovement playerMovement;

    void Awake() {
        playerMovement = PlayerMovement.playerMovement;
    }

    void OnEnable() {
        DialogManager.onDialogClose += activeMovement;
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (DialogManager.dialogManager.activeDialog) return;

        if (collision.CompareTag("Player")) {
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
        DialogManager.dialogManager.scrDialog = dialog;
        DialogManager.dialogManager.startDialog();
    }

    private bool isGrounded() {
        return playerMovement.isGrounded;
    }

    private void activeMovement() {
        playerMovement.enabled = true;
    }
    
    void OnDisable() {
        DialogManager.onDialogClose -= activeMovement;
    }
}