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
        DialogManager.OnDialogOpen += SetupOpenDialog;
        DialogManager.OnDialogClose += SetupCloseDialog;
    }

    void OnDisable() {
        DialogManager.OnDialogOpen -= SetupOpenDialog;
        DialogManager.OnDialogClose -= SetupCloseDialog;
    }

    void OnTriggerStay2D(Collider2D collision) {
        if (collision.CompareTag("Player") && inDialog == false) {
            MustActiveDialog();
        }
    }

    void OnTriggerExit2D(Collider2D collision) {
        if (!collision.CompareTag("Player")) return;

        if (promptPressE != null) {
            promptPressE.SetActive(false);
        }
    }

    private void MustActiveDialog() {
        if (needsInteract) {
            PromptActiveDialogue();
        }
        else {
            if (IsGrounded()) {
                ActiveDialog();
            }
        }
    }

    private void PromptActiveDialogue() {
        promptPressE.SetActive(IsGrounded());

        if (Input.GetKeyDown(KeyCode.E) && IsGrounded()) {
            ActiveDialog();
        }
    }

    private void ActiveDialog() {
        if (promptPressE != null) {
            promptPressE.SetActive(false);
        }
    }

    private bool IsGrounded() {
        return playerMovement.IsGrounded;
    }
    
    private void SetupOpenDialog(){
        inDialog = true;
        playerMovement.enabled = false;
        DialogManager.InstanceDialogManager.Dialogs = dialog.LineDialog;
        DialogManager.InstanceDialogManager.OpenDialog();
    }
    
    private void SetupCloseDialog() {
        inDialog = false;
        playerMovement.enabled = true;
    }
}