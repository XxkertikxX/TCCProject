using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class DialogDisableButtonsTest : RuntimeTestBase
{
    private IDialogSetup dialogDisableButtons;
    private List<Button> buttons = new List<Button>();

    [UnitySetUp]
    public IEnumerator Setup() {
        CreateButtons();
        CreateDialogDisableButtons();
        yield return new WaitForSeconds(0.1f);
    }
    
    [UnityTest]
    public IEnumerator SetupDisableButtons_Test() {
        DisableButtons();
        EnableButtons();
        yield return null;
    }
    
    private void CreateButtons(){
        for(int i = 0; i < 10; i++) {
            GameObject buttonObject = new GameObject("Button" + i);
            Button button = buttonObject.AddComponent<Button>();
            buttons.Add(button);
        }
    }
    
    private void CreateDialogDisableButtons() {
        GameObject dialogObject = new GameObject("DialogDisableButtons");
        dialogDisableButtons = dialogObject.AddComponent<DialogDisableButtons>();
    }
    
    private void DisableButtons() {
        dialogDisableButtons.SetupOpenDialog();
        
        foreach (var button in buttons) {
            Assert.IsFalse(button.interactable);
        }
    }

    private void EnableButtons() {
        dialogDisableButtons.SetupCloseDialog();

        foreach (var button in buttons) {
            Assert.IsTrue(button.interactable);
        }
    }
}
