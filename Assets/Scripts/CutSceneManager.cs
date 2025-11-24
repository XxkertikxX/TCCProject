using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class CutSceneManager : MonoBehaviour
{
    private VideoPlayer player;
    [SerializeField] private string NextScene;
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
        GetComponent<WaitAndLoad>().Play(NextScene);
    }
}
