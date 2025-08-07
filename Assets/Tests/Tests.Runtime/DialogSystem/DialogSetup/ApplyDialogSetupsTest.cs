using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ApplyDialogSetupsTest : RuntimeTestBase
{
    private GameObject dialogObject;

    [UnitySetUp]
    public IEnumerator Setup() { 
        CreateDialogManager();
        yield return new WaitForSeconds(0.1f);
    }

    [UnityTest]
    public IEnumerator ApplyDialogSetups_Test() {
        DialogManager.OpenDialog();
        yield return new WaitForSeconds(0.1f);
        Assert.IsNotNull(dialogObject.GetComponent<Rigidbody2D>());
        Assert.IsNotNull(dialogObject.GetComponent<BoxCollider2D>());

        DialogManager.CloseDialog();
        yield return new WaitForSeconds(0.1f);
        Assert.IsNull(dialogObject.GetComponent<Rigidbody2D>());
        Assert.IsNull(dialogObject.GetComponent<BoxCollider2D>());
    }

    private void CreateDialogManager() {
        dialogObject = new GameObject("DialogManager");
        AddComponents();
    }
    
    private void AddComponents(){
        dialogObject.AddComponent<DialogSetupsTestAddRigidbody2D>();
        dialogObject.AddComponent<DialogSetupsTestAddBoxCollider2D>();
        dialogObject.AddComponent<ApplyDialogSetups>();
    }
}

public class DialogSetupsTestAddRigidbody2D : MonoBehaviour, IDialogSetup
{
    public void SetupOpenDialog() {
        gameObject.AddComponent<Rigidbody2D>();
    }
    
    public void SetupCloseDialog() {
        Destroy(GetComponent<Rigidbody2D>());
    }
}

public class DialogSetupsTestAddBoxCollider2D : MonoBehaviour, IDialogSetup
{
    public void SetupOpenDialog() {
        gameObject.AddComponent<BoxCollider2D>();
    }
    
    public void SetupCloseDialog() {
        Destroy(GetComponent<BoxCollider2D>());
    }
}