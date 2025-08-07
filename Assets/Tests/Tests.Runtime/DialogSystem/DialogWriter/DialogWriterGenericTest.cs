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

        Assert.AreEqual("T", textSpeak.text); //Roda o foreach 1 frame junto do setup, por isso cria uma letra do diálogo
        Assert.AreEqual("Test Character", textName.text);
        Assert.AreEqual(null, imageNPC.sprite);
    }

    /*[UnityTest]
    public IEnumerator Typing_Test() {
        writer.StartLine();

        string text;
        foreach (char c in testDialogs[0].TextDialog) {
            yield return new WaitForSeconds(0.05f);
            text += c;
            Assert.AreEqual(c, )
        }
    }*/

    [UnityTest]
    public IEnumerator WriteLowest_Test() {
        writer.StartLine();

        yield return new WaitForSeconds(1.2f);
        Assert.AreEqual("This is a test dialog.", textSpeak.text);
    }
    
    [UnityTest]
    public IEnumerator WriteFast_Test() {
        writer.StartLine();
        inputSystemTest.Input = new List<string>() {"Jump"};
        yield return new WaitForSeconds(0.5f);
        Assert.AreEqual("This is a test dialog.", textSpeak.text);
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
}