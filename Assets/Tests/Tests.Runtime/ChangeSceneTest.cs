using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class ChangeSceneTest : RuntimeTestBase
{
    private GameObject player;
    private GameObject changeScene;
    private string nameScene = "Tests";

    [UnitySetUp]
    public IEnumerator Setup() {
        CreatePlayer();
        CreateChangeSceneObj();
        yield return null;
    }

    [UnityTest]
    public IEnumerator ChangeScene_Test() {
        player.transform.position = changeScene.transform.position;
        yield return new WaitForSeconds(0.1f);
        Assert.AreEqual(nameScene, SceneManager.GetActiveScene().name);
    }
    
    private void CreatePlayer(){
        player = new GameObject("Player");
        player.tag = "Player";
        player.AddComponent<BoxCollider2D>();
        player.AddComponent<Rigidbody2D>().gravityScale = 0;
    }
    
    private void CreateChangeSceneObj(){
        changeScene = new GameObject("ChangeScene");
        changeScene.AddComponent<ChangeScene>().nextScene = nameScene;
        changeScene.AddComponent<BoxCollider2D>().isTrigger = true;
        changeScene.transform.position = new Vector3(5, 0, 0);
    }
}
