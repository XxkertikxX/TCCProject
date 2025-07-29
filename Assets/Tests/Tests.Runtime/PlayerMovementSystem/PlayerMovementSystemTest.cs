using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerMovementSystemTest : RuntimeTestBase
{
    private GameObject player;
    private PlayerMovementSystem playerMovement;
    private Rigidbody2D rb;

    [UnitySetUp]
    public IEnumerator Setup() {
        CreatePlayer();
        yield return null;
    }

    [UnityTest]
    public IEnumerator Disable_Test() {
        rb.velocity = new Vector3(5, 5);
        playerMovement.enabled = false;
        yield return new WaitForSeconds(0.1f);
        Assert.AreEqual(Vector2.zero, rb.velocity);
    }

    [UnityTest]
    public IEnumerator ApplyMovement_Test() {
        yield return new WaitForSeconds(0.1f);
        Assert.AreEqual(new Vector2(1, 1), rb.velocity);
    }

    private void CreatePlayer() {
        player = new GameObject("Player");
        AddComponents();
    }
    
    private void AddComponents(){
        rb = player.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        playerMovement = player.AddComponent<PlayerMovementSystem>();
        player.AddComponent<MovementTestMoveLeft>();
        player.AddComponent<MovementTestMoveUp>();
    }
}

public class MovementTestMoveLeft : MonoBehaviour, IMovement {public void Move(Rigidbody2D rb) { rb.velocity += Vector2.left;} public bool Apply(IButtonInput input) {return true;}}
public class MovementTestMoveUp : MonoBehaviour, IMovement {public void Move(Rigidbody2D rb) { rb.velocity += Vector2.up;} public bool Apply(IButtonInput input) {return true;}}