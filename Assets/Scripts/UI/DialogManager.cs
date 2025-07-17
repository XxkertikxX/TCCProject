using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DialogManager : MonoBehaviour
{
    public static event Action OnDialogOpen;
    public static event Action OnDialogClose;
    public static DialogManager InstanceDialogManager { get; private set; }
    
    private LineDialog[] dialogs;

    [SerializeField] private Text textName;
    [SerializeField] private Text textSpeak;
    [SerializeField] private Image imageNPC;

    private int index;
    private float actualSpeed;
    private Coroutine coroutine = null;

    void Awake() {
        InstanceDialogManager = this;
    }

    void Update() {
        actualSpeed = WriteSpeed();

        if (Input.GetKeyDown(KeyCode.Return)) {
            ContinueDialog();
        }
    }
    
    public void OpenDialog(ScrDialog dialog) {
        dialogs = dialog.LineDialog;
        index = 0;
        OnDialogOpen?.Invoke();
        StartLine();
    }
    
    private void ContinueDialog() {
        if (coroutine == null) {
            NextLine();
        }
        else {
            SkipLine();
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
            yield return new WaitForSecondsRealtime(actualSpeed);
        }
        coroutine = null;
    }

    private void NextLine() {
        if (index < dialogs.Length - 1) {
            index++;
            StartLine();
        }
        else {
            CloseDialog();
        }
    }

    private void CloseDialog() {
        OnDialogClose?.Invoke();
    }

    private void SetupLine() {
        textName.text = dialogs[index].NameCharacter;
        textSpeak.text = null;
        imageNPC.sprite = dialogs[index].ImageCharacter;
    }

    private float WriteSpeed() {
        return Input.GetKey(KeyCode.Space) ? 0.01f : 0.05f;
    }
}