using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogWriterGeneric : MonoBehaviour, IDialogWriter
{
    [SerializeField] private Text textSpeak;
    [SerializeField] private Text textName;
    [SerializeField] private Image imageNPC;
    private LineDialog[] dialogs;
    private Coroutine coroutine = null;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Return)) {
            ContinueDialog();
        }
    }

    public void StartLine() {
        SetupLine();
        coroutine = StartCoroutine(TypingLine());
    }

    private void ContinueDialog() {
        if (coroutine == null) {
            NextLine();
        }
        else {
            SkipLine();
        }
    }
    
    private void NextLine() {
        int index = 0;
        if (index < dialogs.Length) {
            index++;
            StartLine();
        }
        else {
            DialogManager.CloseDialog();
        }
    }
    private void SkipLine() {
        int index = 0;
        StopCoroutine(coroutine);
        coroutine = null;
        textSpeak.text = dialogs[index].TextDialog;
    }

    private IEnumerator TypingLine() {
        int index = 0;
        foreach (char c in dialogs[index].TextDialog) {
            textSpeak.text += c;
            yield return new WaitForSeconds(WriteSpeed());
        }
        coroutine = null;
    }

    private void SetupLine() {
        int index = 0;
        textSpeak.text = null;
        textName.text = dialogs[index].NameCharacter;
        imageNPC.sprite = dialogs[index].ImageCharacter;
    }

    private float WriteSpeed() {
        const float lowestSpeed = 0.01f;
        const float fastSpeed = 0.05f;
        return Input.GetKey(KeyCode.Space) ? lowestSpeed : fastSpeed;
    }
}