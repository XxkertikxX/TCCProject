using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;
public class DialogManager : MonoBehaviour
{
    public static event Action onDialogClose;
    public static DialogManager dialogManager { get; private set; }
    public bool activeDialog => screenDialog.activeSelf;
    public ScrDialog scrDialog;

    [SerializeField] GameObject screenDialog;
    [SerializeField] GameObject screenHUD;
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

    public void startDialog(){
        setupDialog();
        startLine();
    }

    private void startLine() {
        setupLine();
        StartCoroutine(typingLine());
    }

    private IEnumerator typingLine() {
        foreach (char c in scrDialog.textsDialog[index]) {
            textSpeak.text += c;
            yield return new WaitForSecondsRealtime(actualSpeed);
        }
        readyText = true;
    }

    private void nextLine() {
        if (index < scrDialog.textsDialog.Length) {
            index++;
            startLine();
        }
        else{
            closeDialog();
        }
    }

    private void closeDialog() {
        onDialogClose?.Invoke();
        setupEndDialog();
    }

    private void setupDialog() {
        index = 0;
        Time.timeScale = 0f;
        screenHUD.SetActive(false);
        screenDialog.SetActive(true);
    }
    
    private void setupEndDialog(){
        Time.timeScale = 1f;
        screenDialog.SetActive(false);
        screenHUD.SetActive(true);
    }
    
    private void setupLine(){
        readyText = false;
        textName.text = scrDialog.nameCharacter[index];
        textSpeak.text = null;
        imageNPC.sprite = scrDialog.imageCharacter[index];
    }
}