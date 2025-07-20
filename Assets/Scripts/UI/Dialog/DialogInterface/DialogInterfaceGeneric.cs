using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogInterfaceGeneric : DialogInterfaceBase
{
    [SerializeField] private Text textName;
    [SerializeField] private Image imageNPC;

    private Coroutine coroutine = null;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Return)) {
            ContinueDialog();
        }
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
        if (index < dialogs.Length - 1) {
            index++;
            StartLine();
        }
        else {
            DialogManager.InstanceDialogManager.CloseDialog();
        }
    }
    private void SkipLine() {
        StopCoroutine(coroutine);
        coroutine = null;
        textSpeak.text = dialogs[index].TextDialog;
    }

    private void StartLine() {
        SetupLine();
        coroutine = StartCoroutine(TypingLine());
    }

    private IEnumerator TypingLine() {
        foreach (char c in dialogs[index].TextDialog) {
            textSpeak.text += c;
            yield return new WaitForSecondsRealtime(WriteSpeed());
        }
        coroutine = null;
    }

    private void SetupLine() {
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
