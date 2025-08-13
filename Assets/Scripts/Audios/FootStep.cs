using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStep : MonoBehaviour
{
    public void PlapFootSteps()
    {
        GameAudioManager.PlaySound(SoundTypes.Footsteps);
    }
}
