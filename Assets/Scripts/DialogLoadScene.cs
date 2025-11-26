using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogLoadScene : MonoBehaviour
{
    [SerializeField] private string sceneDialog;

    private void OnEnable()
    {
        DialogManager.OnDialogClose += LoadScene;
    }
    private void OnDisable()
    {
        DialogManager.OnDialogClose -= LoadScene;
    }

    private void LoadScene()
    {
        SceneFade.instance.EnterEnviromentScene(sceneDialog);
    }
}
