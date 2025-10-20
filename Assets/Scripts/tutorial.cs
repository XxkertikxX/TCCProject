using System;
using UnityEngine;

public class tutorial : MonoBehaviour
{
    [SerializeField] private TutorialConditions[] tutorialList;
    private TutorialConditions actualTutorial;
    private int index = 0;
    private bool waitingInput;

    [Header("Fade Config")]
    [SerializeField] private float FadeDuration;
    [SerializeField] private float FadeSpeed;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            TutorialConditions();
            actualTutorial = tutorialList[index];
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Player") {
            Debug.Log(index);
            actualTutorial.TutorialGO.SetActive(false); //aprimorar
            actualTutorial.TutorialCol.enabled = false;
        }
    }

    private void Update() {
        if (!waitingInput || index > tutorialList.Length)
            return;

        foreach (string bind in tutorialList[index].BindsPressed) {
            if (InputCatalyst.input.InputButtonDown(bind)) {
                CheckIfPressed();
            }
        }
    }

    private void TutorialConditions() {
        tutorialList[index].TutorialGO.SetActive(true);
        waitingInput = true;
    }

    private void CheckIfPressed() {
        waitingInput = false;
        index++;
    }
}

[Serializable]
public struct TutorialConditions {
    public GameObject TutorialGO;
    public string[] BindsPressed;
    public Collider2D TutorialCol;

    public TutorialConditions(GameObject tutorialGO, string[] binds, Collider2D col) {
        TutorialGO = tutorialGO;
        BindsPressed = binds;
        TutorialCol = col;
    }
}

