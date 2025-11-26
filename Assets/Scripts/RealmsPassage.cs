using UnityEngine;

public class RealmsPassage : MonoBehaviour
{
    [SerializeField] private CinematicPlayed[] battleConcluded;
    [SerializeField] private GameObject[] battleConcludedColliders;
    private void Start()
    {
        int battlesWonCount = 0;
        for (int i = 0; i < battleConcluded.Length; i++)
        {
            if (battleConcluded[i].WasPlayed)
            {
                battlesWonCount++;
            }
        }

        switch (battlesWonCount)
        {
            case 1:
                battleConcludedColliders[0].SetActive(true);
                battleConcludedColliders[1].SetActive(false);
                break;
            case 2:
                battleConcludedColliders[1].SetActive(true);
                battleConcludedColliders[0].SetActive(false);
                break;
            default:
                for(int i = 0; i < battleConcludedColliders.Length; i++)
                {
                    battleConcludedColliders[i].SetActive(false);
                }
                break;
        }

    }
}


