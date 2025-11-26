using UnityEngine;
using UnityEngine.Video;

public class PlayVIdeoOnEnable : MonoBehaviour
{
    private void OnEnable()
    {
        GetComponent<VideoPlayer>().Play();
    }

    private void OnDisable()
    {
        GetComponent<VideoPlayer>().gameObject.SetActive(false);
    }
}
