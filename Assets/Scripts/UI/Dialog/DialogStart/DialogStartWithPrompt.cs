using UnityEngine;

public class DialogStartWithPrompt : DialogStartBase
{
    [SerializeField] private GameObject promptPressKey;

    private PlayerMovement playerMovement;
    private bool inDialog;

    void Awake() {
        playerMovement = PlayerMovement.InstancePlayerMovement;
    }

    void OnTriggerStay2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            PromptActiveDialogue();
        }
    }

    void OnTriggerExit2D(Collider2D collision) {
        promptPressKey.SetActive(false);
    }
    
    protected override void SetupOpenDialog(){
        inDialog = true;
        playerMovement.enabled = false;
    }
    
    protected override void SetupCloseDialog() {
        inDialog = false;
        playerMovement.enabled = true;
    }
    
    private void PromptActiveDialogue() {
        promptPressKey.SetActive(CanActivePrompt());

        if (Input.GetKeyDown(KeyCode.E) && CanActivePrompt()) {
            StartDialog();
        }
    }

    private bool CanActivePrompt(){
        return IsGrounded() && !inDialog;
    }
    
    private bool IsGrounded() {
        return playerMovement.IsGrounded;
    }
}