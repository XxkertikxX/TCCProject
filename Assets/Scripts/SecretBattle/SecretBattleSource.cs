using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretBattleSource : MonoBehaviour
{
    [SerializeField] private CinematicPlayed[] totalBattlesWon;
    private void Awake()
    {
        int count = 0;
        foreach (var kvp in totalBattlesWon)
        {
            if (kvp.WasPlayed)
            {
                count++;
            }
        }
        if (count == totalBattlesWon.Length)
            gameObject.SetActive(true);
        else
            gameObject.SetActive(false);
    }
}
