using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private string sceneName;
    private SceneFade _sceneFade;

    private void Start()
    {
        _sceneFade = FindObjectOfType<SceneFade>();
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            _sceneFade.EnterEnviromentScene(sceneName);
        }
    }
}
