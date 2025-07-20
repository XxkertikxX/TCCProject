using UnityEngine;

public class DialogStartWithPrompt : DialogStartBase
{
    [SerializeField] private GameObject promptPressKey;

    private PlayerMovement playerMovement;

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
    
    private void PromptActiveDialogue() {
        promptPressKey.SetActive(CanActivePrompt());

        if (Input.GetKeyDown(KeyCode.E) && CanActivePrompt()) {
            StartDialog();
        }
    }

    private bool CanActivePrompt(){
        return IsGrounded() && playerMovement.enabled;
    }
    
    private bool IsGrounded() {
        return playerMovement.IsGrounded;
    }
}