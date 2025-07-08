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
    private bool readyText;

    void Awake() {
        dialogManager = this;
    }

    void Update() {
        actualSpeed = Input.GetKey(KeyCode.Space) ? 0.01f : 0.05f;

        if (readyText && Input.GetKeyDown(KeyCode.Space)){
            nextLine();
        }
    }

    public void openDialog(){
        onDialogOpen?.Invoke();
        startLine();
    }

    private void startLine() {
        setupLine();
        StartCoroutine(typingLine());
    }

    private IEnumerator typingLine() {
        readyText = false;
        foreach (char c in dialogs[index].textsDialog) {
            textSpeak.text += c;
            yield return new WaitForSecondsRealtime(actualSpeed);
        }
        readyText = true;
    }

    private void nextLine() {
        if (index < dialogs.Length - 1) {
            index++;
            startLine();
        }
        else{
            closeDialog();
        }
    }

    private void closeDialog() {
        onDialogClose?.Invoke();
    }
    
    private void setupLine(){
        readyText = false;
        textName.text = dialogs[index].nameCharacter;
        textSpeak.text = null;
        imageNPC.sprite = dialogs[index].imageCharacter;
    }
}