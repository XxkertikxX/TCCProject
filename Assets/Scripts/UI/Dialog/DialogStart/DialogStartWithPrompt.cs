using UnityEngine;

public class DialogStartWithPrompt : DialogStartBase
{
    [SerializeField] private GameObject promptPressKey;

    private PlayerMovementSystem playerMovement;

    void Awake() {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementSystem>();
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
        return playerMovement.verticalMovementCondiction.CanMove();
    }
}