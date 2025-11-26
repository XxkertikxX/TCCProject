using UnityEngine;

public class AfterBatle : MonoBehaviour
{
    [SerializeField] private CinematicPlayed battleConcluded;

    private void Start()
    {
        if (!battleConcluded.WasPlayed)
        {
            gameObject.SetActive(false);
        }
    }
}
