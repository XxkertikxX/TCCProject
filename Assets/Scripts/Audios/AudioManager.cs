using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] audioClip;

    public void MouseInteractions() {
        audioSource.clip = audioClip[IndexAudio()];
        
        if (!audioSource.isPlaying) {
            audioSource.Play();
        }
        else {
            audioSource.Stop();
            audioSource.Play();
        }
    }

    private int IndexAudio() {
        return Random.Range(0, audioClip.Length);
    }
}