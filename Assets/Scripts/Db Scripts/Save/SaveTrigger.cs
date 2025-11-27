using UnityEngine;
using System;
using System.Collections;
using UnityEngine.Video;

public class SaveTrigger : MonoBehaviour
{
    static public event Action OnDeath;
    private bool morreu = false;
    [SerializeField] private GameObject MorreuMenu;
    [SerializeField] private bool video = false;
    [SerializeField] private GameObject VideoPlayer;

    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player") && !morreu) {
            //GameObject.FindObjectOfType<SaveLoader>().Load();
            if (video)
            {
                VideoPlayer.SetActive(true);
                VideoPlayer.GetComponent<VideoPlayer>().Play();
                StartCoroutine(tocarVideo());
            }
            else
            {
                MorreuMenu.SetActive(true);
                OnDeath?.Invoke();
                StartCoroutine(Morreu());
            }
        }
    }

    private IEnumerator Morreu() {
        morreu = true;
        yield return new WaitForSeconds(3f);
        morreu = false;
    }

    private IEnumerator tocarVideo()
    {
        yield return new WaitForSeconds(3f);
        Time.timeScale = 0f;
        MorreuMenu.SetActive(true);
        OnDeath?.Invoke();
        StartCoroutine(Morreu());
    }
}
