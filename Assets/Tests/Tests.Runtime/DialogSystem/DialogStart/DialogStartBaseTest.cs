using NUnit.Framework;
using UnityEngine;

public class DialogStartBaseTest : RuntimeTestBase
{
    private DialogStartBase dialogStart;

    [SetUp]
    public void Setup() {
        CreateDialogStartSystem();
    }
    
    [Test]
    public void CallEvents_Test() {
        bool wasCalledLocal = false;
        bool wasCalledGlobal = false;
        dialogStart.OnDialogOpen += () => wasCalledLocal = true;
        DialogManager.OnDialogOpen += () => wasCalledGlobal = true;
        dialogStart.StartDialog();
        Assert.IsTrue(wasCalledLocal && wasCalledGlobal);
    }
    
    private void CreateDialogStartSystem() {
        GameObject dialog = new GameObject("Dialog");
        dialogStart = dialog.AddComponent<DialogStartBase>();
    }
}
