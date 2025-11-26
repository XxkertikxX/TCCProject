using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBossChecjers : MonoBehaviour
{
    [SerializeField] CinematicPlayed[] SOs;

    public void ResetValue()
    {
        foreach(var c in SOs)
        {
            c.WasPlayed = false;
        }
    }
}
