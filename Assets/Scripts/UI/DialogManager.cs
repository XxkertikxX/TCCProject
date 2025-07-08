using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DialogManager : MonoBehaviour
{
    public static event Action onDialogOpen;
    public static event Action onDialogClose;
    public static DialogManager dialogManager { get; private set; }
    public LineDialog[] dialogs;

    [SerializeField] Text textName;
    [SerializeField] Text textSpeak;
    [SerializeField] Image imageNPC;

    private int index;
    private float actualSpeed;
    private Coroutine coroutine = null;

    void Awake() {
        dialogManager = this;
    }

    void Update() {
        actualSpeed = writeSpeed();

        if (Input.GetKeyDown(KeyCode.Return)) {
            ContinueDialog();
        }
    }

    private void ContinueDialog() {
        if (coroutine == null) {
            nextLine();
        }
        else {
            SkipLine();
        }
    }

    private void SkipLine() {
        StopCoroutine(coroutine);
        coroutine = null;
        textSpeak.text = dialogs[index].textDialog;
    }
    
    public void openDialog() {
        index = 0;
        onDialogOpen?.Invoke();
        startLine();
    }

    private void startLine() {
        setupLine();
        coroutine = StartCoroutine(typingLine());
    }

    private IEnumerator typingLine() {
        foreach (char c in dialogs[index].textDialog) {
            textSpeak.text += c;
            yield return new WaitForSecondsRealtime(actualSpeed);
        }
        coroutine = null;
    }

    private void nextLine() {
        if (index < dialogs.Length - 1) {
            index++;
            startLine();
        }
        else {
            closeDialog();
        }
    }

    private void closeDialog() {
        onDialogClose?.Invoke();
    }

    private void setupLine() {
        textName.text = dialogs[index].nameCharacter;
        textSpeak.text = null;
        imageNPC.sprite = dialogs[index].imageCharacter;
    }

    private float writeSpeed() {
        return Input.GetKey(KeyCode.Space) ? 0.01f : 0.05f;
    }
}