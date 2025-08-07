using NUnit.Framework;
using UnityEngine;

public class DialogStartSystemTest : RuntimeTestBase
{
    private DialogStartSystem dialogSystem;

    private ScrDialog dialog;
    private DialogStartBase dialogStart;

    [SetUp]
    public void Setup() {
        CreateDialogSystem();
    }

    [Test]
    public void VerifyFields_Test() {
        dialogStart.StartDialog();
        Assert.AreEqual(dialog.LineDialog, CatalystDialog.Dialog);
        Assert.AreEqual(dialogStart.GetComponent<IDialogWriter>(), CatalystDialog.Writer);
    }

    private void CreateDialogSystem() {
        GameObject dialog = new GameObject("Dialog");
        dialog.SetActive(false);
        dialogSystem = dialog.AddComponent<DialogStartSystem>();
        dialog.AddComponent<WriterTest>();
        SetAndGetScrDialog();
        SetAndGetDialogStartBase(dialog);
        dialog.SetActive(true);
    }
    
    private void SetAndGetScrDialog() {
        Reflection.SetField(dialogSystem, "dialog", ScrDialogCreator.NewScrDialog());
        dialog = Reflection.GetField<ScrDialog>(dialogSystem, "dialog");
    }
    
    private void SetAndGetDialogStartBase(GameObject dialog) {
        Reflection.SetField(dialogSystem, "dialogStart", dialog.AddComponent<DialogStartBase>());
        dialogStart = Reflection.GetField<DialogStartBase>(dialogSystem, "dialogStart");
    }
}

public class WriterTest : MonoBehaviour, IDialogWriter {
    public void Constructor(LineDialog[] dialogs){}
    public void StartLine(){}
}