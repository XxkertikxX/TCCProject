using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class LifeBarTest : RuntimeTestBase
{
    private ILifeUI lifeBar;

    private Text lifeText;
    private Slider lifeSlider;

    [UnitySetUp]
    public IEnumerator Setup() {
        CreateLifeBar();
        CreateUI();
        yield return new WaitForSeconds(0.1f);
    }

    [UnityTest]
    public IEnumerator UpdateUI_Test() {
        const float actualLife = 50f;
        const float maxLife = 100f;

        lifeBar.UpdateUI(actualLife, maxLife);
        yield return new WaitForSeconds(0.1f);

        Assert.AreEqual($"{actualLife} / {maxLife}".Replace(" ", ""), lifeText.text.Replace(" ", ""));
        Assert.AreEqual(actualLife / maxLife, lifeSlider.value);
    }

    private void CreateLifeBar() {
        lifeBar = new LifeBar();
    }
    
    private void CreateUI() {
        CreateLifeText();
        CreateLifeSlider();
    }
    
    private void CreateLifeText() {
        lifeText = new GameObject("LifeText").AddComponent<Text>();
        Reflection.SetField(lifeBar, "lifeText", lifeText);
    }
    
    private void CreateLifeSlider() {
        lifeSlider = new GameObject("LifeText").AddComponent<Slider>();
        Reflection.SetField(lifeBar, "lifeSlider", lifeSlider);
    }
}