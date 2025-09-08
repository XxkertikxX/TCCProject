using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DialogWriterGeneric : MonoBehaviour, IDialogWriter
{
	public event Action<int> OnPassLine;
	
    private string[] dialogs;

    [SerializeField] private Text textSpeak;
    
    private Coroutine coroutine = null;

    private int index = 0;
    private bool inDialog;

    void Update() {
        if (!inDialog) return;
        
        if (InputCatalyst.input.InputButtonDown("Skip")) {
            ContinueDialog();
        }
    }

    public void Constructor(string[] dialogs) => this.dialogs = dialogs;

    public void StartLine() {
        inDialog = true;
        index = 0;
        SetupLine();
        coroutine = StartCoroutine(TypingLine());
    }
    
    private void SetupLine() {
        textSpeak.text = null;
		OnPassLine?.Invoke(index);
    }
    
    private void ContinueDialog() {
        if (coroutine == null) {
            NextLine();
            return;
        }
        SkipLine();
    }
    
    private void NextLine() {
        index++;
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
        textSpeak.text = dialogs[index];
    }

    private IEnumerator TypingLine() {
        yield return null;
        foreach (char c in dialogs[index]) {
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