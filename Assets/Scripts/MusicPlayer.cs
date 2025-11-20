using System;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private LevelsMusic[] musics;
    private MusicPlayer instance;
    private AudioSource musicAudioSource;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        musicAudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (musicAudioSource.isPlaying)
            return;

        PlayMusic(SceneManager.GetActiveScene(), new Scene());
    }

    private void PlayMusic(Scene actual, Scene next)
    {
        for (int i = 0; i < musics.Length; i++)
        {
            if (musics[i].SceneName == actual.name && !musicAudioSource.isPlaying)
                instance.musicAudioSource.PlayOneShot(musics[i].MusicClip, GameAudioManager.getTypeOfVolume(SoundTypes.Music));
        }
    }

    private void OnEnable()
    {
        SceneManager.activeSceneChanged += PlayMusic;
    }

    private void OnDisable()
    {
        SceneManager.activeSceneChanged -= PlayMusic;
    }
}

[Serializable]
public struct LevelsMusic
{
    public string SceneName;
    public AudioClip MusicClip;
}