using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class DialogDisableMovementTest : RuntimeTestBase
{
    private PlayerMovementSystem playerMovement;
    private IDialogSetup dialogDisableMovement;

    [UnitySetUp]
    public IEnumerator Setup() {
        CreatePlayer();
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
        GameObject player = new GameObject("Player");
        player.tag = "Player";
        playerMovement = player.AddComponent<PlayerMovementSystem>();
        dialogDisableMovement = player.AddComponent<DialogDisableMovement>();
    }
}