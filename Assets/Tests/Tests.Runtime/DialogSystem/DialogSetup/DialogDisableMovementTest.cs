using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class DialogDisableMovementTest : RuntimeTestBase
{
    private GameObject player;
    private PlayerMovementSystem playerMovement;
    private IDialogSetup dialogDisableMovement;

    [UnitySetUp]
    public IEnumerator Setup() {
        CreatePlayer();
        AddFieldsPlayer();
        yield return new WaitForSeconds(0.1f);
    }

    [Test]
    public void SetupDisableMovement_Test() {
        dialogDisableMovement.SetupOpenDialog();
        Assert.IsFalse(playerMovement.enabled);

        dialogDisableMovement.SetupCloseDialog();
        Assert.IsTrue(playerMovement.enabled);
    }
    
    private void CreatePlayer() {
        player = new GameObject("Player");
        player.tag = "Player";
        player.AddComponent<Rigidbody2D>();
        player.AddComponent<InputSystemTest>();
        playerMovement = player.AddComponent<PlayerMovementSystem>();
        dialogDisableMovement = player.AddComponent<DialogDisableMovement>();
    }
    
    private void AddFieldsPlayer() {
        LayerMask mask = 1 << LayerMask.NameToLayer("Ground");
        Reflection.SetField(playerMovement, "ground", mask);
        Reflection.SetField(playerMovement, "groundCheck", new GameObject("GroundCheck").transform);
    }
}