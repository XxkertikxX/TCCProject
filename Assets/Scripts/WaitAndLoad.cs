using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaitAndLoad : MonoBehaviour
{
    [SerializeField] Animator fadeAnim;

    public void Play(string sceneName)
    {
        StartCoroutine(WaL(sceneName));
    }

    private IEnumerator WaL(string sceneName)
    {
        fadeAnim.Play("FadeOut");
        yield return new WaitForSeconds(.8f);
        SceneManager.LoadScene(sceneName);
    }
}
