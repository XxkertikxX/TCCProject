using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBossChecjers : MonoBehaviour
{
    [SerializeField] CinematicPlayed[] SOs;

    public void ResetValue()
    {
        SOs[0].WasPlayed = false;
        SOs[1].WasPlayed = false;
        SOs[2].WasPlayed = false;
        foreach (var c in SOs)
        {
            c.WasPlayed = false;
        }
    }
}
