using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

public class ScriptTesteTurno : MonoBehaviour
{
    [Header("Ui Elements")]
    [SerializeField] private Text actionText;
    [SerializeField] private List<Transform> circleTurn;
    [SerializeField] private Animator animator;

    [SerializeField] GameObject[] amountOfCharsInGame;
    int indexTurn = 0;

    [SerializeField] CanvasGroup group;
    Coroutine fadeInAndOut;
    [SerializeField] float animationDuration;

    void Start()
    {
        DoPersonaCircle();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (indexTurn != amountOfCharsInGame.Length-1)
            {
                indexTurn++;
            }
            else
            {
                indexTurn = 0;
            }
            UndoAllCircles();
            DoPersonaCircle();
        }
    }

    void UndoAllCircles()
    {
        for (int i = 0; i < circleTurn.Count; i++)
        {
            if (circleTurn[i] != null)
                circleTurn[i].gameObject.SetActive(false);
        }
    }
    void DoPersonaCircle()
    {
        bool isPersona = amountOfCharsInGame[indexTurn].CompareTag("Player");

        animator.SetBool("IsCharactersTurn", isPersona);

        if (indexTurn < circleTurn.Count)
            circleTurn[indexTurn].gameObject.SetActive(true);
        else
            UndoAllCircles();

        FadeInAndOut(isPersona);
    }

    void FadeInAndOut(bool isPersona)
    {
        if (fadeInAndOut != null)
            StopCoroutine(FadeAnimation(0, null));

        if (isPersona)
        {
            fadeInAndOut = StartCoroutine(FadeAnimation(1, null));
            actionText.gameObject.SetActive(false);
        }
        else
        {
            fadeInAndOut = StartCoroutine(FadeAnimation(0, $"{amountOfCharsInGame[indexTurn].name} está atacando!"));
            actionText.gameObject.SetActive(true);
        }
    }

    IEnumerator FadeAnimation(float alphaDesired, string Text)
    {
        yield return new WaitForSeconds(animationDuration);

        group.alpha = alphaDesired;

        if(actionText != null)
            actionText.text = Text;
    }
}
