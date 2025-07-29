using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerMovementWalkTest : RuntimeTestBase
{
    private Rigidbody2D rb;
    private InputSystemTest inputSystemTest;
    private float speed;

    [UnityTest]
    public IEnumerator MovementRight_Test(){
        DefineInputs(new List<string>(){"Right"});
        yield return new WaitForSeconds(0.1f);
        Assert.AreEqual(speed, rb.velocity.x);
    }

    [UnityTest]
    public IEnumerator MovementLeft_Test(){
        DefineInputs(new List<string>(){"Left"});
        yield return new WaitForSeconds(0.1f);
        Assert.AreEqual(-speed, rb.velocity.x);
    }

    [UnityTest]
    public IEnumerator MovementLeftAndRight_Test(){
        DefineInputs(new List<string>(){"Left", "Right"});
        yield return new WaitForSeconds(0.1f);
        Assert.AreEqual(0, rb.velocity.x);
    }

    private void DefineInputs(List<string> inputs) {
        inputSystemTest.Input = inputs;
    }
}
