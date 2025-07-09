using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] audioClip;

    public void mouseInteractions() {
        audioSource.clip = audioClip[indexAudio()];
        
        if (!audioSource.isPlaying) {
            audioSource.Play();
        }
        else {
            audioSource.Stop();
            audioSource.Play();
        }
    }

    private int indexAudio() {
        return Random.Range(0, audioClip.Length);
    }
}