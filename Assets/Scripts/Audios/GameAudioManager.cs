using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource)), ExecuteInEditMode]
public class GameAudioManager : MonoBehaviour
{
    [SerializeField] private SoundList[] soundsList;
    private static GameAudioManager instance;
    private AudioSource audioSource;

    public static float soundVolume = 1;
    public static float musicVolume = 1;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(SoundTypes audioClips) {
        AudioClip[] clips = instance.soundsList[(int)audioClips].Sounds;
        AudioClip randomClip = clips[UnityEngine.Random.Range(0,clips.Length)];
        if (CheckIfMusic(audioClips))
            instance.audioSource.PlayOneShot(randomClip, getTypeOfVolume(audioClips));
    }

    public static void PlayNonRandomSound(SoundTypes audioClips, int clipToPlay)
    {
        AudioClip[] clips = instance.soundsList[(int)audioClips].Sounds;
        if (CheckIfMusic(audioClips))
            instance.audioSource.PlayOneShot(clips[clipToPlay], getTypeOfVolume(audioClips));
    }

    private static bool CheckIfMusic(SoundTypes clip)
    {
        if(clip != SoundTypes.Music)
            return true;
        else
            return false;
    }

    private static float getTypeOfVolume(SoundTypes s) {
        if(s != SoundTypes.Music) {
            return soundVolume;
        }
        else {
            return musicVolume;
        }
    }

#if UNITY_EDITOR
    private void OnEnable() {
        string[] names = Enum.GetNames(typeof(SoundTypes));
        Array.Resize(ref soundsList, names.Length);
        for (int i = 0; i < soundsList.Length; i++) {
            soundsList[i].name = names[i];
        }
    }

#endif
}
[Serializable]
public struct SoundList {
    public AudioClip[] Sounds { get => sounds; }
    [HideInInspector] public string name;
    [SerializeField] private AudioClip[] sounds;
}