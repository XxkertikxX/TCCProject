using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciarAudio : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip[] _audioClip;

    public void InteracoesMouse()
    {
        int indexSom = Random.Range(0, _audioClip.Length);
        _audioSource.clip = _audioClip[indexSom];
        if (!_audioSource.isPlaying)
        {
            _audioSource.Play();
        }
        else
        {
            _audioSource.Stop();
            _audioSource.Play();
        }
    }
}
