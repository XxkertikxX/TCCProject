using System;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private LevelsMusic[] musics;
    private MusicPlayer instance;
    [SerializeField] private AudioSource musicAudioSource;

    private void Awake() //fazer fadeIn e fadeOut no audio
    {
        instance = this;
        musicAudioSource = GetComponent<AudioSource>();
        Debug.Log(musicAudioSource.isPlaying);
    }

    private void Update()
    {
        musicAudioSource.volume = GameAudioManager.musicVolume;
    }

    private void PlayMusic(Scene actual, LoadSceneMode a)
    {
        for (int i = 0; i < musics.Length; i++)
        {
            for (int j = 0; j < musics[i].ScenesWithMusic.Length; j++)
            {
                if (musicAudioSource.isPlaying)
                {
                    Debug.Log("Cena tocando: " + musics[i].ScenesWithMusic[j] + "|| Musica tocando: " + musics[i].MusicClip.name);
                    //return;
                }
                
                if (musics[i].ScenesWithMusic[j] == SceneManager.GetActiveScene().name)
                {
                    instance.musicAudioSource.clip = musics[i].MusicClip;
                    instance.musicAudioSource.Play();
                    return;
                }
                else
                {
                    musicAudioSource.Stop();
                    //PlayMusic(SceneManager.GetActiveScene(), new LoadSceneMode());
                }
            }
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += PlayMusic;
        
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= PlayMusic;
    }
}

[Serializable]
public struct LevelsMusic
{
    public string Title;
    public string[] ScenesWithMusic;
    public AudioClip MusicClip;
}