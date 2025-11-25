using UnityEngine;

public class FootStep : MonoBehaviour
{
    public SoundTypes typeOfGround;
    public void PlayFootSteps()
    {
        GameAudioManager.PlaySound(typeOfGround);
    }
}
