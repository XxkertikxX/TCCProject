using Codice.Client.BaseCommands.WkStatus.Printers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundTypes
{
    Footsteps,
    Jump,
    Landing,
    Damage
}

[RequireComponent(typeof(AudioSource))]

public class CharacterAudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] soundsList;  
    private static CharacterAudioManager instance;
    private AudioSource audioSource;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(SoundTypes audioClip, float volume = 1)
    {
        instance.audioSource.PlayOneShot(instance.soundsList[(int)audioClip], volume);
    }
}
