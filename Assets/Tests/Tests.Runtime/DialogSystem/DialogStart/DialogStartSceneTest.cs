using System;
using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class DialogStartSceneTest : RuntimeTestBase
{
    private ScrDialog scrDialog;

    [UnityTest]
    public IEnumerator StartDialog_Test() {
        bool wasCalled = false;
        DialogManager.OnDialogOpen += () => wasCalled = true;
        CreateDialogStartScene();
        yield return new WaitForSeconds(0.1f);
        Assert.IsTrue(wasCalled);
        Assert.AreEqual(CatalystDialog.Dialog, scrDialog.LineDialog);
    }
    
    private void CreateDialogStartScene() {
        GameObject dialogObject = new GameObject("DialogStartScene");
        DialogStartScene dialogStartScene = dialogObject.AddComponent<DialogStartScene>();
        Type dialogStartSceneType = dialogStartScene.GetType();
        Type dialogStartBase = dialogStartSceneType.BaseType;
        scrDialog = ScrDialogCreator.NewScrDialog();
        Reflection.SetField(dialogStartScene, "dialog", scrDialog);
    }
}
