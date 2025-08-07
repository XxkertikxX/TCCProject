using UnityEngine;
using NUnit.Framework;

public class RuntimeTestInput : RuntimeTestBase
{
    protected InputSystemTest inputSystemTest;

    [SetUp]
    public void SetupInput() {
        CreateInputSystem();
    }

    private void CreateInputSystem() {
        GameObject input = new GameObject("Input");
        inputSystemTest = input.AddComponent<InputSystemTest>();
    }
}