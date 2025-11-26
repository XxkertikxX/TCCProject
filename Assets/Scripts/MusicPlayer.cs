using System;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private GameVolumeSO volumeSO;
    [SerializeField] private LevelsMusic[] musics;
    public static MusicPlayer instance;
    [SerializeField] private AudioSource musicAudioSource;
    public static float musicVolume = 0.5f;

    private void Awake() //fazer fadeIn e fadeOut no audio
    {
        instance = this;
    }

    private void Update()
    {
        musicAudioSource.volume = volumeSO.musicVolume;
        //Debug.Log("Som variavel " + musicVolume);
        //Debug.Log("Som armazenado " + volumeSO.musicVolume);
    }
    public void ChangeVolumeRoot()
    {
        volumeSO.musicVolume = musicVolume;
    }

    private void PlayMusic(Scene actual, LoadSceneMode a)
    {
        for (int i = 0; i < musics.Length; i++)
        {
            for (int j = 0; j < musics[i].ScenesWithMusic.Length; j++)
            {
                if (musics[i].ScenesWithMusic[j] == SceneManager.GetActiveScene().name)
                {
                    if (musicAudioSource.clip == musics[i].MusicClip)
                    {
                        return;
                    }
                    else
                    {
                        musicAudioSource.Stop();
                    }

                    instance.musicAudioSource.clip = musics[i].MusicClip;
                    instance.musicAudioSource.Play();
                    return;
                }
            }
        }
        musicAudioSource.Stop();
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