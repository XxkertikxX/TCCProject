using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class DialogStartWithPromptTest : RuntimeTestBase
{
    private DialogStartWithPrompt dialogPrompt;
    private GameObject prompt;

    [SetUp]
    public void Setup() {
        CreatePlayer();
        prompt = new GameObject("Prompt");
        CreateDialogPrompt();
    }

    [UnityTest]


    private void CreatePlayer() {
        GameObject player = new GameObject("Player");
        player.tag = "Player";
        player.AddComponent<PlayerMovementSystem>();
        player.AddComponent<BoxCollider2D>();
    }

    private void CreateDialogPrompt() {
        GameObject dialogPromptObj = new GameObject("DialogPrompt");
        dialogPrompt = dialogPromptObj.AddComponent<DialogStartWithPrompt>();
        dialogPromptObj.AddComponent<BoxCollider2D>().isTrigger = true;
    }
}
