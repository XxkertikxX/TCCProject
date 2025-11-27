using System;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource)), ExecuteInEditMode]
public class GameAudioManager : MonoBehaviour
{

    [SerializeField] private SoundList[] soundsList;
    public static GameAudioManager instance;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private GameVolumeSO volumeSO;

    public static float soundVolume;


    private void Awake() {
        instance = this;
    }

    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        audioSource.volume = volumeSO.soundsVolume;
        Debug.Log(volumeSO.musicVolume);
    }

    public void ChangeVolumeRoot()
    {
        volumeSO.soundsVolume = soundVolume;
    }

    public static void PlaySound(SoundTypes audioClips)
    {
        AudioClip[] clips = instance.soundsList[(int)audioClips].Sounds;
        AudioClip randomClip = clips[UnityEngine.Random.Range(0, clips.Length)];
        instance.audioSource.PlayOneShot(randomClip, soundVolume);
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

