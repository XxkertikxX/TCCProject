using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class DestroyDeathTest : RuntimeTestBase
{
    private GameObject deathObject;
    private IDeath destroyDeath;

    [UnitySetUp]
    public IEnumerator Setup() {
        CreateDestroyDeathObject();
        yield return new WaitForSeconds(0.1f);
    }

    [UnityTest]
    public IEnumerator DestroyOnDeath_Test() {
        destroyDeath.Death();
        yield return new WaitForSeconds(0.1f);
        Assert.IsTrue(deathObject == null);
    }
    
    private void CreateDestroyDeathObject() {
        deathObject = new GameObject("DeathObject");
        destroyDeath = deathObject.AddComponent<DestroyDeath>();
    }
}