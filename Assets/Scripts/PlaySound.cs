using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public void PlaySelectedSound(SoundTypes TypeOfSound)
    {
        GameAudioManager.PlaySound(TypeOfSound);
    }
}
