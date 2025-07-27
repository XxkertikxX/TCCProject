using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class DialogEnableUITest : RuntimeTestBase
{
    private IDialogSetup dialogEnableUI;
    private GameObject UI;
    private GameObject HUD;

    [SetUp]
    public void Setup() {
        UI = new GameObject("UI");
        HUD = new GameObject("HUD");
        CreateDialogEnableUI();
    }
    
    [Test]
    public void SetupDialogEnableUI_Test() {
        dialogEnableUI.SetupOpenDialog();
        Assert.IsTrue(UI.activeSelf);
        Assert.IsFalse(HUD.activeSelf);

        dialogEnableUI.SetupCloseDialog();
        Assert.IsFalse(UI.activeSelf);
        Assert.IsTrue(HUD.activeSelf);
    }

    private void CreateDialogEnableUI() {
        GameObject dialogObject = new GameObject("DialogEnableUI");
        dialogEnableUI = dialogObject.AddComponent<DialogEnableUI>();
        Reflection.SetField(dialogEnableUI, "screenDialog", UI);
        Reflection.SetField(dialogEnableUI, "screenHUD", HUD);
    }
}
