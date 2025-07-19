using System.Collections;
using System.Data;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.TextCore.Text;

public class LifeSystemTest : RuntimeTestBase
{
    private GameObject Character;
    private LifeSystem lifeSystem;

    [UnitySetUp]
    public IEnumerator Setup() {
        CreateCharacter();
        yield return new WaitForSeconds(0.1f);
    }

    private void CreateCharacter() {
        Character = new GameObject("Character");
        AddCharacterComponents();
        lifeSystem = Character.AddComponent<LifeSystem>();
    }
    
    [UnityTest]
    public IEnumerator AddLife_Test() {
        const float lifeToAdd = 30f;
        const float lifeToRemove = -60f;
        const float expectedLife = 100 + lifeToAdd + lifeToRemove;

        lifeSystem.AddLife(lifeToRemove);
        lifeSystem.AddLife(lifeToAdd);
        yield return new WaitForSeconds(0.1f);

        Assert.AreEqual(expectedLife, GetActualLife());
    }

    [UnityTest]
    public IEnumerator AddLifeClamp_Test() { 
        const float lifeToAdd = 20f;
        
        lifeSystem.AddLife(lifeToAdd);
        yield return new WaitForSeconds(0.1f);
        Assert.AreEqual(100, GetActualLife());
    }

    [UnityTest]
    public IEnumerator UpdateUI_Test() { 
        lifeSystem.AddLife(0);
        yield return new WaitForSeconds(0.1f);
        Assert.NotNull(Character.GetComponent<BoxCollider2D>());
    }
    
    [UnityTest]
    public IEnumerator Death_Test() { 
        lifeSystem.AddLife(-200f);
        yield return new WaitForSeconds(0.1f);
        Assert.NotNull(Character.GetComponent<Rigidbody2D>());
    }
    
    private void AddCharacterComponents() {
        CreateStatusCharacter();
        Character.AddComponent<LifeUITest>();
        Character.AddComponent<DeathTest>();
    }
    
    private void CreateStatusCharacter() {
        var status = ScriptableObject.CreateInstance<StatusCharacters>();
        status.hp = 100f;
        Character.AddComponent<CharacterStatus>().Character = status;
    }
    
    private float GetActualLife() {
        return Reflection.GetField<float>(lifeSystem, "actualLife");
    }
}

public class LifeUITest : MonoBehaviour, ILifeUI
{
    public void UpdateUI(float actualLife, float maxLife) {
        gameObject.AddComponent<BoxCollider2D>();
    }
}

public class DeathTest : MonoBehaviour, IDeath
{
    public void Death() {
        gameObject.AddComponent<Rigidbody2D>();
    }
}