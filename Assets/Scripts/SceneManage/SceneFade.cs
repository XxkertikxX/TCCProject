using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFade : MonoBehaviour
{
    private Animator fadeAnimator;
    private string nextScene;
    public static SceneFade instance;
    [SerializeField] private Transform Panel;

    private void Awake() {
        fadeAnimator = GetComponent<Animator>();
        instance = this;
    }

    public void EnterEnviromentScene(string name) {
        nextScene = name;
        fadeAnimator.SetTrigger("EnterScene");
    }
    public void OnfadeComplete()  {
        SceneManager.LoadScene(nextScene);
    }
    public void OnFadeInComplete()
    {
        Panel.gameObject.SetActive(false);
    }
    public void OnFadeOutStart()
    {
        Panel.gameObject.SetActive(true);
    }
}
