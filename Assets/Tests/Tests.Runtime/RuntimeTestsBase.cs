using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using System.Collections;

public class RuntimeTestBase
{
    protected string testSceneName = "TestsRuntime";

    [UnitySetUp]
    public virtual IEnumerator LoadTestScene() {
        if (SceneManager.GetActiveScene().name != testSceneName) {
            SceneManager.LoadScene(testSceneName);
            yield return new WaitUntil(() => SceneManager.GetActiveScene().name == testSceneName);
        }
    }
    
    [UnityTearDown]
    public virtual IEnumerator CleanupScene() {
        foreach (var obj in Object.FindObjectsOfType<GameObject>()) {
            Object.Destroy(obj);
        }

        yield return null;
    }
}