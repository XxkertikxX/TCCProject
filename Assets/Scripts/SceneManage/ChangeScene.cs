using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private DefineBattleConfigSO defineBattleConfigSO;
    [SerializeField] private string sceneName;
    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            //SceneFade.instance.EnterEnviromentScene(sceneName);
            defineBattleConfigSO.DefineSO();
            SceneManager.LoadScene(sceneName);
        }
    }
}
