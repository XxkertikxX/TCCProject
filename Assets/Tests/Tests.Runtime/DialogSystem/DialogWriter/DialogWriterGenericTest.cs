using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class DialogWriterGeneric_Test : RuntimeTestInput
{
    private DialogWriterGeneric writer;

    private Text textSpeak;
    private Text textName;
    private Image imageNPC;

    private LineDialog[] testDialogs;
    private bool closeDialogCalled;

    [SetUp]
    public void Setup() {
        GameObject dialogWriter = new GameObject("DialogWriter");

        writer = dialogWriter.AddComponent<DialogWriterGeneric>();
        SetUI(writer);

        writer.Constructor(ScrDialogCreator.NewScrDialog().LineDialog);
        testDialogs = Reflection.GetField<LineDialog[]>(writer, "dialogs");
    }

    [Test]
    public void SetupLine_Test() {
        writer.StartLine();
        Assert.AreEqual(string.Empty, textSpeak.text);
        Assert.AreEqual("Test Character", textName.text);
        Assert.AreEqual(null, imageNPC.sprite);
    }

    [UnityTest]
    public IEnumerator WriteLowest_Test() {
        writer.StartLine();
        yield return AssertTyping(0, 0.05f);
        Assert.AreEqual("Test Character", textName.text);
    }
    
    [UnityTest]
    public IEnumerator WriteFast_Test() {
        writer.StartLine();
        inputSystemTest.Input = new List<string>() {"Jump"};
        yield return AssertTyping(0, 0.02f);
        Assert.AreEqual("Test Character", textName.text);
    }

    [UnityTest]
    public IEnumerator PassText_Test() {
        writer.StartLine();

        Assert.AreEqual("Test Character", textName.text);
        inputSystemTest.Input = new List<string>() {"Skip"}; 

        yield return null;

        Assert.AreEqual(testDialogs[0].TextDialog, textSpeak.text);

        yield return null;

        Assert.AreEqual("Test", textName.text);
        inputSystemTest.Input = new List<string>() {};
        
        yield return AssertTyping(1, 0.05f);
    }

    private void SetUI(DialogWriterGeneric writer) {
        Reflection.SetField(writer, "textSpeak", CreateUIText());
        Reflection.SetField(writer, "textName", CreateUIText());
        Reflection.SetField(writer, "imageNPC", CreateUIImage());

        textSpeak = Reflection.GetField<Text>(writer, "textSpeak");
        textName = Reflection.GetField<Text>(writer, "textName");
        imageNPC = Reflection.GetField<Image>(writer, "imageNPC");
    }
    
    private Text CreateUIText() {
        GameObject go = new GameObject("Text");
        return go.AddComponent<Text>();
    }

    private Image CreateUIImage() {
        GameObject go = new GameObject("Image");
        return go.AddComponent<Image>();
    }

    private IEnumerator AssertTyping(int pos, float time) {
        string text = null;
        foreach(char c in testDialogs[pos].TextDialog.ToCharArray()) {
            yield return new WaitForSeconds(time);
            text += c;
            Assert.AreEqual(text, textSpeak.text);
        }
    }
}