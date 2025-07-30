using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class DialogStartWithPromptTest : RuntimeTestBase
{
    private DialogStartWithPrompt dialogPrompt;
    private GameObject prompt;

    private PlayerMovementSystem playerMovement;
    private InputSystemTest inputSystemTest;

    [SetUp]
    public void Setup() {
        CreatePlayer();
        CreateDialogPrompt();
        CreatePrompt();
    }

    [UnityTest]
    public IEnumerator VerifyIfPromptActive() {
        yield return new WaitForSeconds(0.1f);
        Assert.IsTrue(prompt.activeInHierarchy);
    }

    [UnityTest]
    public IEnumerator VerifyIfDialogOpen(){
        inputSystemTest.Input = new List<string>();
        yield return null;
    }

    private void CreatePlayer() {
        GameObject player = new GameObject("Player");
        player.tag = "Player";
        playerMovement = player.AddComponent<PlayerMovementSystem>();
        player.AddComponent<BoxCollider2D>();
        inputSystemTest = player.AddComponent<InputSystemTest>();
        player.AddComponent<InputCatalyst>();
    }

    private void CreatePrompt() {
        prompt = new GameObject("Prompt");
        Reflection.SetField(dialogPrompt, "promptPressKey", prompt);
        prompt.SetActive(false);
    }

    private void CreateDialogPrompt() {
        GameObject dialogPromptObj = new GameObject("DialogPrompt");
        dialogPrompt = dialogPromptObj.AddComponent<DialogStartWithPrompt>();
        dialogPromptObj.AddComponent<BoxCollider2D>().isTrigger = true;
    }
}
