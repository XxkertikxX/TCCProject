using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerMovementJumpTest : RuntimeTestBase
{
    private List<string> jump = new List<string>(){"Jump"};
    private List<string> notJump = new List<string>(){"Not Jump"};
    private Vector3 isGrounded = new Vector3(0, 0, 0);
    private Vector3 notGrounded = new Vector3(0, 5, 0);

    private GameObject player;

    private IMovement playerMovementJump;

    private Rigidbody2D rb;
    private InputSystemTest input;

    private float jumpForce; 

    [SetUp]
    public void Setup() {
        CreatePlayer();
        CreateGround();
        CreateGroundCheck();
        AddFieldLayerGround();
        jumpForce = Reflection.GetField<float>(playerMovementJump, "jumpForce");
    }

    [UnityTest]
    public IEnumerator Jump_Test() {
        playerMovementJump.Move(rb);
        yield return new WaitForSeconds(0.1f);
        Assert.AreEqual(jumpForce, rb.velocity.y);
    }

    [UnityTest]
    public IEnumerator IsGroundedAndInputTrue_Test() {
        DefineInputs(jump);
        player.transform.position = isGrounded;
        yield return new WaitForSeconds(0.1f);
        Assert.IsTrue(playerMovementJump.Apply(input));
    }

    [UnityTest]
    public IEnumerator IsNotGroundedAndInputTrue_Test() {
        DefineInputs(jump);
        player.transform.position = notGrounded;
        yield return new WaitForSeconds(0.1f);
        Assert.IsFalse(playerMovementJump.Apply(input));
    }

    [UnityTest]
    public IEnumerator IsGroundedAndInputFalse_Test() {
        DefineInputs(notJump);
        player.transform.position = isGrounded;
        yield return new WaitForSeconds(0.1f);
        Assert.IsFalse(playerMovementJump.Apply(input));
    }

    [UnityTest]
    public IEnumerator IsNotGroundedAndInputFalse_Test() {
        DefineInputs(notJump);
        player.transform.position = notGrounded;
        yield return new WaitForSeconds(0.1f);
        Assert.IsFalse(playerMovementJump.Apply(input));
    }

    private void CreatePlayer() {
        player = new GameObject("Player");
        playerMovementJump = player.AddComponent<PlayerMovementJump>();
        rb = player.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        input = player.AddComponent<InputSystemTest>();
        DefineInputs(new List<string>(){"Jump"});
    }

    private void CreateGroundCheck() {
        GameObject groundCheck = new GameObject("GroundCheck");
        groundCheck.transform.SetParent(player.transform);
        groundCheck.transform.localPosition = new Vector3(0, -1, 0);
    }

    private void CreateGround() {
        GameObject ground = new GameObject("Ground");
        ground.AddComponent<BoxCollider2D>().size = new Vector2(10, 1);
        ground.transform.position = new Vector3(0, -1, 0);
        ground.layer = LayerMask.NameToLayer("Ground");
    }

    private void AddFieldLayerGround() {
        LayerMask mask = 1 << LayerMask.NameToLayer("Ground");
        Reflection.SetField(playerMovementJump, "ground", mask);
    }

    private void DefineInputs(List<string> inputs) {
        input.Input = inputs;
    }
}