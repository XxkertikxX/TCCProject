using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip[] _audioClip;

    public void mouseInteractions() {
        _audioSource.clip = _audioClip[indexAudio()];
        
        if (!_audioSource.isPlaying) {
            _audioSource.Play();
        }
        else {
            _audioSource.Stop();
            _audioSource.Play();
        }
    }

    private int indexAudio() {
        return Random.Range(0, _audioClip.Length);
    }
}