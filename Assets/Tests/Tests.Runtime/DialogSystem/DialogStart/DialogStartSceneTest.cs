using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class DialogStartSceneTest : RuntimeTestBase
{
    [UnityTest]
    public IEnumerator StartDialog_Test() {
        bool wasCalled = false;
        DialogManager.OnDialogOpen += () => wasCalled = true;
        CreateDialogStartScene();
        yield return new WaitForSeconds(0.1f);
        Assert.IsTrue(wasCalled);
    }
    
    private void CreateDialogStartScene() {
        GameObject dialogObject = new GameObject("DialogStartScene");
        dialogObject.AddComponent<DialogStartScene>();
    }
}
