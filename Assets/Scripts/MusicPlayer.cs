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
            for (int j = 0; j < musics[i].ScenesWithMusic.Length; j++)
            {
                if (musics[i].ScenesWithMusic[j] == actual.name && !musicAudioSource.isPlaying)
                {
                    instance.musicAudioSource.PlayOneShot(musics[i].MusicClip, GameAudioManager.getTypeOfVolume(SoundTypes.Music));
                    Debug.Log("Cena tocando: " + musics[i].ScenesWithMusic[j]);
                }
            }
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
    public string Title;
    public string[] ScenesWithMusic;
    public AudioClip MusicClip;
}