using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerMovementJumpTest : RuntimeTestInput
{
    private List<string> jump = new List<string>(){"Jump"};
    private List<string> notJump = new List<string>(){"Not Jump"};
    private Vector3 isGrounded = new Vector3(0, 0, 0);
    private Vector3 notGrounded = new Vector3(0, 5, 0);

    private GameObject player;

    private IMovement playerMovementJump;
    private MovementProperties movementProperties;

    private Rigidbody2D rb;

    private float jumpForce; 

    [SetUp]
    public void Setup() {
        CreatePlayer();
        CreateGround();
        CreateGroundCheck();
        AddFieldLayerGround();
        jumpForce = movementProperties.JumpForce * movementProperties.MultiplierJumpForce;
    }

    [UnityTest]
    public IEnumerator Jump_Test() {
        playerMovementJump.Move(rb, movementProperties);
        yield return new WaitForSeconds(0.1f);
        Assert.AreEqual(jumpForce, rb.velocity.y);
    }

    [UnityTest]
    public IEnumerator IsGroundedAndInputTrue_Test() {
        DefineInputs(jump);
        player.transform.position = isGrounded;
        yield return new WaitForSeconds(0.1f);
        Assert.IsTrue(playerMovementJump.Apply(inputSystemTest));
    }

    [UnityTest]
    public IEnumerator IsNotGroundedAndInputTrue_Test() {
        DefineInputs(jump);
        player.transform.position = notGrounded;
        yield return new WaitForSeconds(0.1f);
        Assert.IsFalse(playerMovementJump.Apply(inputSystemTest));
    }

    [UnityTest]
    public IEnumerator IsGroundedAndInputFalse_Test() {
        DefineInputs(notJump);
        player.transform.position = isGrounded;
        yield return new WaitForSeconds(0.1f);
        Assert.IsFalse(playerMovementJump.Apply(inputSystemTest));
    }

    [UnityTest]
    public IEnumerator IsNotGroundedAndInputFalse_Test() {
        DefineInputs(notJump);
        player.transform.position = notGrounded;
        yield return new WaitForSeconds(0.1f);
        Assert.IsFalse(playerMovementJump.Apply(inputSystemTest));
    }

    private void CreatePlayer() {
        player = new GameObject("Player");
        playerMovementJump = player.AddComponent<PlayerMovementJump>();
        movementProperties = player.AddComponent<MovementProperties>();
        rb = player.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        DefineInputs(new List<string>(){"Jump"});
    }

    private void CreateGroundCheck() {
        GameObject groundCheck = new GameObject("GroundCheck");
        groundCheck.transform.SetParent(player.transform);
        groundCheck.transform.localPosition = new Vector3(0, -1, 0);
        Reflection.SetField(playerMovementJump, "groundCheck", groundCheck.transform);
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
        inputSystemTest.Input = inputs;
    }
}