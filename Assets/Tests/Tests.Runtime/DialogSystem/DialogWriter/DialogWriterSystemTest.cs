using NUnit.Framework;
using UnityEngine;

public class DialogWriterSystemTest : RuntimeTestBase
{
    private DialogWriterSystem dialogWriterSystem;

    private MockDialogWriter mockWriter;
    private LineDialog[] mockDialogs;

    [SetUp]
    public void Setup() {
        GameObject dialogWriter = new GameObject("DialogWriterSystem");
        dialogWriterSystem = dialogWriter.AddComponent<DialogWriterSystem>();

        SetFields(dialogWriter);

        DialogManager.OpenDialog();
    }

    [Test]
    public void InvokesConstructorAndStartLine_Test() {
        Assert.IsTrue(mockWriter.ConstructorCalled);
        Assert.IsTrue(mockWriter.StartLineCalled);
        Assert.AreEqual(mockDialogs, mockWriter.Dialogs);
    }

    [Test]
    public void VerifyField_Test() {
        Assert.AreEqual(mockWriter.GetComponent<IDialogWriter>(), Reflection.GetField<IDialogWriter>(dialogWriterSystem, "dialogWriter"));
        Assert.AreEqual(mockDialogs, Reflection.GetField<LineDialog[]>(dialogWriterSystem, "dialogs"));
    }

    private void SetFields(GameObject dialogWriter) {
        mockWriter = dialogWriter.AddComponent<MockDialogWriter>();
        mockDialogs = new LineDialog[] { new LineDialog() };

        CatalystDialog.Writer = mockWriter;
        CatalystDialog.Dialog = mockDialogs;
    }
}

public class MockDialogWriter : MonoBehaviour, IDialogWriter {
    public bool ConstructorCalled { get; private set; }
    public bool StartLineCalled { get; private set; }
    public LineDialog[] Dialogs { get; private set; }

    public void Constructor(LineDialog[] dialogs) {
        ConstructorCalled = true;
        Dialogs = dialogs;
    }

    public void StartLine() {
        StartLineCalled = true;
    }
}