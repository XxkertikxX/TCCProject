using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogWriterGeneric : MonoBehaviour, IDialogWriter
{
    private LineDialog[] dialogs;

    [SerializeField] private Text textSpeak;
    [SerializeField] private Text textName;
    [SerializeField] private Image imageNPC;
    
    private Coroutine coroutine = null;

    private int index = 0;
    private bool inDialog;

    void Update() {
        if (!inDialog) return;
        
        if (Input.GetKeyDown(KeyCode.Return)) {
            ContinueDialog();
        }
    }

    public void Constructor(LineDialog[] dialogs) => this.dialogs = dialogs;

    public void StartLine() {
        inDialog = true;
        index = 0;
        SetupLine();
        coroutine = StartCoroutine(TypingLine());
    }
    
    private void SetupLine() {
        textSpeak.text = null;
        textName.text = dialogs[index].NameCharacter;
        imageNPC.sprite = dialogs[index].ImageCharacter;
    }
    
    private void ContinueDialog() {
        index++;
        if (coroutine == null) {
            NextLine();
            return;
        }
        SkipLine();
    }
    
    private void NextLine() {
        if (index < dialogs.Length) {
            SetupLine();
            coroutine = StartCoroutine(TypingLine());
            return;
        }
        inDialog = false;
        DialogManager.CloseDialog();
    }
    
    private void SkipLine() {
        StopCoroutine(coroutine);
        coroutine = null;
        textSpeak.text = dialogs[index].TextDialog;
    }

    private IEnumerator TypingLine() {
        foreach (char c in dialogs[index].TextDialog) {
            textSpeak.text += c;
            yield return new WaitForSeconds(WriteSpeed());
        }
        coroutine = null;
    }

    private float WriteSpeed() {
        const float lowestSpeed = 0.05f;
        const float fastSpeed = 0.02f;
        return InputCatalyst.input.InputButton("Jump") ? fastSpeed : lowestSpeed;
    }
}