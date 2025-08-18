using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerMovementWalkTest : RuntimeTestInput
{
    private Rigidbody2D rb;
    private PlayerMovementWalk playerMovementWalk;
    private MovementProperties movementProperties;

    [SetUp]
    public void Setup() {
        CreatePlayer();
    }

    [UnityTest]
    public IEnumerator MovementRight_Test(){
        ApplyMovement(new List<string>(){"Right"});
        yield return new WaitForSeconds(0.1f);
        Assert.AreEqual(GetSpeed(), rb.velocity.x);
    }

    [UnityTest]
    public IEnumerator MovementLeft_Test(){
        ApplyMovement(new List<string>(){"Left"});
        yield return new WaitForSeconds(0.1f);
        Assert.AreEqual(-GetSpeed(), rb.velocity.x);
    }

    [UnityTest]
    public IEnumerator MovementLeftAndRight_Test(){
        ApplyMovement(new List<string>(){"Left", "Right"});
        yield return new WaitForSeconds(0.1f);
        Assert.AreEqual(0, rb.velocity.x);
    }

    private void CreatePlayer() {
        GameObject player = new GameObject("Player");
        rb = player.AddComponent<Rigidbody2D>();
        playerMovementWalk = player.AddComponent<PlayerMovementWalk>();
        movementProperties = player.AddComponent<MovementProperties>();
    }

    private float GetSpeed() {
        return movementProperties.Speed * movementProperties.MultiplierSpeed;
    }

    private void ApplyMovement(List<string> inputs) {
        inputSystemTest.Input = inputs;
        playerMovementWalk.Apply(inputSystemTest);
        playerMovementWalk.Move(rb, movementProperties);
    }
}