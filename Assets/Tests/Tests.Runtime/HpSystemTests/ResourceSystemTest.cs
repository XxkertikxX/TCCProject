using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ResourceSystemTest : RuntimeTestBase
{
    private ResourceSystem resourceSystem;

    private ValueUITest ui;

    [UnitySetUp]
    public IEnumerator Setup() {
        CreateCharacter();
        yield return new WaitForSeconds(0.1f);
    }

    private void CreateCharacter() {
        GameObject Character = new GameObject("Character");
        ui = Character.AddComponent<ValueUITest>();
        resourceSystem = Character.AddComponent<ResourceSystem>();
        resourceSystem.Constructor(100);
    }
    
    [UnityTest]
    public IEnumerator AddValue_Test() {
        const float valueToAdd = 30f;
        const float valueToRemove = -60f;
        const float expectedValue = 100 + valueToAdd + valueToRemove;

        resourceSystem.ModifyValue(valueToRemove);
        resourceSystem.ModifyValue(valueToAdd);
        yield return new WaitForSeconds(0.1f);

        Assert.AreEqual(expectedValue, GetActualValue());
    }

    [UnityTest]
    public IEnumerator AddValueClamp_Test() { 
        const float valueToAdd = 20f;
        
        resourceSystem.ModifyValue(valueToAdd);
        yield return new WaitForSeconds(0.1f);
        Assert.AreEqual(100, GetActualValue());
    }

    [UnityTest]
    public IEnumerator UpdateUI_Test() { 
        resourceSystem.ModifyValue(0);
        yield return new WaitForSeconds(0.1f);
        Assert.IsTrue(ui.IsChanged);
    }
    
    private float GetActualValue() {
        return Reflection.GetField<float>(resourceSystem, "actualValue");
    }
}

public class ValueUITest : MonoBehaviour, IDinamicUI
{
    public bool IsChanged;
    
    public void UpdateUI(float actualLife, float maxLife) {
        IsChanged = true;
    }
}