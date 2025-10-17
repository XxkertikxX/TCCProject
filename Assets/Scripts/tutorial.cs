using System;
using UnityEngine;

public class tutorial : MonoBehaviour
{
    [SerializeField] private TutorialConditions[] tutorialList;
    private int index = 0;
    private bool waitingInput;

    [Header("Fade Config")]
    [SerializeField] private float FadeDuration;
    [SerializeField] private float FadeSpeed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            TutorialConditions();
            GetComponent<Collider2D>().enabled = false;
        }
    }

    private void Update()
    {
        if (!waitingInput || index > tutorialList.Length)
            return;

        foreach (string bind in tutorialList[index].bindsPressed)
        {
            if (InputCatalyst.input.InputButtonDown(bind))
            {
                CheckIfPressed();
            }
        }
    }

    private void TutorialConditions()
    {
        tutorialList[index].tutorialGo.SetActive(true);
        waitingInput = true;
    }

    private void CheckIfPressed()
    {
        tutorialList[index].tutorialGo.SetActive(false);
        waitingInput = false;
        index++;
    }
}

[Serializable]
public struct TutorialConditions
{
    public GameObject tutorialGo;
    public string[] bindsPressed;

    public TutorialConditions(GameObject t, string[] binds)
    {
        tutorialGo = t;
        bindsPressed = binds;
    }
}

