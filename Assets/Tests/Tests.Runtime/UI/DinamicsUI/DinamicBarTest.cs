using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class LifeBarTest : RuntimeTestBase
{
    private IDinamicUI bar;

    private Text valueText;
    private Slider valueSlider;

    [UnitySetUp]
    public IEnumerator Setup() {
        CreateBar();
        CreateUI();
        yield return new WaitForSeconds(0.1f);
    }

    [UnityTest]
    public IEnumerator UpdateUI_Test() {
        const float actualValue = 50f;
        const float maxValue = 100f;

        bar.UpdateUI(actualValue, maxValue);
        yield return new WaitForSeconds(0.1f);

        Assert.AreEqual($"{actualValue} / {maxValue}".Replace(" ", ""), valueText.text.Replace(" ", ""));
        Assert.AreEqual(actualValue / maxValue, valueSlider.value);
    }

    private void CreateBar() {
        GameObject value = new GameObject("Value");
        bar = value.AddComponent<DinamicUIBar>();
    }
    
    private void CreateUI() {
        CreateText();
        CreateSlider();
    }
    
    private void CreateText() {
        valueText = new GameObject("Text").AddComponent<Text>();
        Reflection.SetField(bar, "valueText", valueText);
    }
    
    private void CreateSlider() {
        valueSlider = new GameObject("Slider").AddComponent<Slider>();
        Reflection.SetField(bar, "valueSlider", valueSlider);
    }
}