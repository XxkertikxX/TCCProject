using UnityEngine;

public class FootStep : MonoBehaviour
{
    public SoundTypes typeOfGround; 

    public void PlapFootSteps()
    {
        GameAudioManager.PlaySound(typeOfGround);
    }
}
