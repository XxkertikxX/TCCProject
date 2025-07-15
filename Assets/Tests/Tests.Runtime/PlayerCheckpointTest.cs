using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerCheckpointTest
{
    private GameObject player;
    private GameObject checkpoint;
    private GameObject hole;

    [UnitySetUp]
    public IEnumerator Setup() {
        CreatePlayer();
        checkpoint = CreateGameObject("Checkpoint", new Vector3(5, 0, 0));
        hole = CreateGameObject("Hole", new Vector3(10, 0, 0));
        yield return new WaitForSeconds(0.1f);
    }

    [UnityTest]
    public IEnumerator CheckpointStart_Test() {
        Vector3 expectedPosition = player.transform.position;
        player.transform.position = new Vector3(10, 0, 0);
        yield return new WaitForSeconds(0.1f);
        Assert.AreEqual(expectedPosition, player.transform.position);
    }

    [UnityTest]
    public IEnumerator CheckpointHole_Test() {
        player.transform.position = new Vector3(5, 0, 0);
        yield return new WaitForSeconds(0.1f);
        player.transform.position = new Vector3(10, 0, 0);
        yield return new WaitForSeconds(0.1f);
        Assert.AreEqual(checkpoint.transform.position, player.transform.position);
    }

    [UnityTearDown]
    public IEnumerator TearDown() {
        GameObject.Destroy(player);
        GameObject.Destroy(checkpoint);
        GameObject.Destroy(hole);
        yield return new WaitForSeconds(0.1f);
    }
    
    private void CreatePlayer() {
        player = new GameObject("Player");
        player.AddComponent<PlayerCheckpoint>();
        player.AddComponent<BoxCollider2D>();
        player.AddComponent<Rigidbody2D>().gravityScale = 0;
    }
    
    private GameObject CreateGameObject(string name, Vector3 position) {
        GameObject obj = new GameObject(name);
        obj.tag = name;
        BoxCollider2D box2D = obj.AddComponent<BoxCollider2D>();
        box2D.isTrigger = true;
        obj.transform.position = position;
        return obj;
    }
}