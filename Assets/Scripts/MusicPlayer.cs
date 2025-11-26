using System;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private LevelsMusic[] musics;
    private MusicPlayer instance;
    private AudioSource musicAudioSource;

    private void Awake() //fazer fadeIn e fadeOut no audio
    {
        instance = this;
    }

    private void Start()
    {
        musicAudioSource = GetComponent<AudioSource>();
        PlayMusic(SceneManager.GetActiveScene(), new Scene());
    }

    private void Update()
    {
        musicAudioSource.volume = GameAudioManager.musicVolume;

        if (musicAudioSource.isPlaying)
            return;

        
    }

    private void PlayMusic(Scene actual, Scene next)
    {
        for (int i = 0; i < musics.Length; i++)
        {
            for (int j = 0; j < musics[i].ScenesWithMusic.Length; j++)
            {
                if (musics[i].ScenesWithMusic[j] == actual.name && !musicAudioSource.isPlaying)
                {
                    instance.musicAudioSource.clip = musics[i].MusicClip;
                    instance.musicAudioSource.Play();
                    Debug.Log("Cena tocando: " + musics[i].ScenesWithMusic[j] + "|| Musica tocando: " + musics[i].MusicClip.name);
                }
                if (actual.name != musics[i].ScenesWithMusic[j] && musicAudioSource.isPlaying)
                {
                    instance.musicAudioSource.Stop();
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