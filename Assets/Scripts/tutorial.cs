using UnityEngine;
using UnityEngine.UI;

public class tutorial : MonoBehaviour
{
    [SerializeField] private GameObject[] Tutorial;
    private int TutorialIndex;

    [Header("Fade Config")]
    [SerializeField] private float FadeDuration;
    [SerializeField] private float FadeSpeed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            for (int i = 0; i < Tutorial.Length; i++)
            {

            }
        }
    }

    private void TutorialConditions()
    {
        Image controles;
        switch (TutorialIndex)
        {
            case 0:
                //controles = 
                break;
        }
    }
}

public struct TutorialRequirements
{
    public GameObject tutorialObjects;
    public Input 
}
