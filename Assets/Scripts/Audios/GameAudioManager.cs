using System;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource)), ExecuteInEditMode]
public class GameAudioManager : MonoBehaviour
{

    [SerializeField] private SoundList[] soundsList;
    public static GameAudioManager instance;
    private AudioSource audioSource;
    [SerializeField] private GameVolumeSO volumeSO;

    public static float soundVolume;
    public static float musicVolume;

    private void Awake() {
        instance = this;
        soundVolume = volumeSO.soundsVolume;
        musicVolume = volumeSO.musicVolume;
    }

    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        audioSource.volume = soundVolume;
    }

    public void ChangeVolumeRoot()
    {
        volumeSO.soundsVolume = soundVolume;
        volumeSO.musicVolume = musicVolume;
    }

    public static void PlaySound(SoundTypes audioClips)
    {
        AudioClip[] clips = instance.soundsList[(int)audioClips].Sounds;
        AudioClip randomClip = clips[UnityEngine.Random.Range(0, clips.Length)];
        instance.audioSource.PlayOneShot(randomClip, getTypeOfVolume(audioClips));
    }

    public static float getTypeOfVolume(SoundTypes s) {
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

