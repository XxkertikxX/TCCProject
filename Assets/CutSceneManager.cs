using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class CutSceneManager : MonoBehaviour
{
    VideoPlayer player;
    private void Awake()
    {
        player = GetComponent<VideoPlayer>();
    }

    private void OnEnable()
    {
        player.loopPointReached += OnVideoEnd;
    }

    private void OnDisable()
    {
        player.loopPointReached -= OnVideoEnd;
    }

    private void OnVideoEnd(VideoPlayer player)
    {
        SceneManager.LoadScene("MainMenu");
    }
}
