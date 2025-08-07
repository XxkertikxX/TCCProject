using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class DialogStartWithPromptTest : RuntimeTestInput
{
    private GameObject player;

    private DialogStartWithPrompt dialogPrompt;
    private GameObject prompt;

    private PlayerMovementSystem playerMovement;

    [SetUp]
    public void Setup() {
        CreatePlayer();
        CreateDialogPrompt();
        CreatePrompt();
    }

    [UnityTest]
    public IEnumerator VerifyIfPromptActive() {
        player.transform.position = Vector3.zero;
        playerMovement.enabled = true;
        yield return new WaitForSeconds(0.1f);
        Assert.IsTrue(prompt.activeInHierarchy);
    }

    public IEnumerator VerifyIfPromptIsNotActivePlayerMovement() {
        playerMovement.enabled = false;
        yield return new WaitForSeconds(0.1f);
        Assert.IsFalse(prompt.activeInHierarchy);
    }

    [UnityTest]
    public IEnumerator VerifyIfPromptIsNotActiveOnExit() {
        playerMovement.enabled = true;
        player.transform.position = new Vector3(10, 10, 10);
        yield return new WaitForSeconds(0.1f);
        Assert.IsFalse(prompt.activeInHierarchy);
    }

    [UnityTest]
    public IEnumerator VerifyIfDialogOpen() {
        bool wasCalled = false;
        inputSystemTest.Input = new List<string>() { "Interact" };
        DialogManager.OnDialogOpen += () => wasCalled = true;
        yield return new WaitForSeconds(0.1f);
        Assert.IsTrue(wasCalled);
    }

    private void CreatePlayer() {
        player = new GameObject("Player");
        player.tag = "Player";
        playerMovement = player.AddComponent<PlayerMovementSystem>();
        player.AddComponent<BoxCollider2D>();
    }

    private void CreatePrompt() {
        prompt = new GameObject("Prompt");
        Reflection.SetField(dialogPrompt, "promptPressKey", prompt);
        prompt.SetActive(false);
    }

    private void CreateDialogPrompt() {
        GameObject dialogPromptObj = new GameObject("DialogPrompt");
        dialogPromptObj.AddComponent<DialogManager>();
        dialogPrompt = dialogPromptObj.AddComponent<DialogStartWithPrompt>();
        dialogPromptObj.AddComponent<BoxCollider2D>().isTrigger = true;
    }
}
