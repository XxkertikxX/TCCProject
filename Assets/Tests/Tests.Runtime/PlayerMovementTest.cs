using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerMovementTest : RuntimeTestBase
{
    private GameObject player;
    private GameObject ground;

    private PlayerMovementForTest playerMovement;
    private Rigidbody2D rb;

    private float speed;
    private float jumpForce;

    [UnitySetUp]
    public IEnumerator Setup() {
        CreatePlayer();
        CreateGround();
        Reflection.SetField(playerMovement, "groundCheck", CreateGroundCheck().transform);
        AddFieldLayerGround();
        yield return null;
    }

    [UnityTest]
    public IEnumerator MovementRight_Test(){
        DefineInputs(true, false, false);
        yield return new WaitForSeconds(0.1f);
        Assert.AreEqual(speed, rb.velocity.x);
    }

    [UnityTest]
    public IEnumerator MovementLeft_Test(){
        DefineInputs(false, true, false);
        yield return new WaitForSeconds(0.1f);
        Assert.AreEqual(-speed, rb.velocity.x);
    }

    [UnityTest]
    public IEnumerator MovementLeftAndRight_Test(){
        DefineInputs(true, true, false);
        yield return new WaitForSeconds(0.1f);
        Assert.AreEqual(0, rb.velocity.x);
    }

    [UnityTest]
    public IEnumerator Jump_Test() {
        DefineInputs(false, false, true);
        yield return null; //Simular GetKeyDown, porém se no PlayerMovement o método InputKeyDown for 
        //alterado incorretamente, dará sucesso no teste mas não funcionará, o teste é parcialmente falho,
        //ele apenas testa o pulo em si e supõe que o resto está correto.
        playerMovement.jump = false;
        yield return new WaitForSeconds(0.1f);
        Assert.AreEqual(jumpForce, rb.velocity.y);
    }

    [UnityTest]
    public IEnumerator IsNotGrounded_Test() {
        player.transform.position = new Vector3(0, 5, 0);
        yield return new WaitForSeconds(0.1f);
        Assert.IsFalse(playerMovement.IsGrounded);
    }

    [UnityTest]
    public IEnumerator IsGrounded_Test() {
        player.transform.position = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(0.1f);
        Assert.IsTrue(playerMovement.IsGrounded);
    }

    [UnityTest]
    public IEnumerator Disable_Test() {
        rb.velocity = new Vector3(5, 5);
        playerMovement.enabled = false;
        yield return new WaitForSeconds(0.1f);
        Assert.AreEqual(Vector2.zero, rb.velocity);
    }

    private void CreatePlayer() {
        player = new GameObject("Player");
        AddRidigbody2D();
        playerMovement = player.AddComponent<PlayerMovementForTest>();
        AddFieldsPlayer();
    }
    
    private void AddRidigbody2D(){
        rb = player.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
    }
    
    private void AddFieldsPlayer(){
        Reflection.SetField(playerMovement, "speed", 5f);
        speed = Reflection.GetField<float>(playerMovement, "speed");
        Reflection.SetField(playerMovement, "jumpForce", 10f);
        jumpForce = Reflection.GetField<float>(playerMovement, "jumpForce");
    }
    private GameObject CreateGroundCheck() {
        var groundCheck = new GameObject("GroundCheck");
        groundCheck.transform.SetParent(player.transform);
        groundCheck.transform.localPosition = new Vector3(0, -1, 0);
        return groundCheck;
    }

    private void CreateGround(){
        ground = new GameObject("Ground");
        ground.AddComponent<BoxCollider2D>().size = new Vector2(10, 1);
        ground.transform.position = new Vector3(0, -1, 0);
        ground.layer = LayerMask.NameToLayer("Ground");
    }
    
    private void AddFieldLayerGround(){
        LayerMask mask = 1 << LayerMask.NameToLayer("Ground");
        Reflection.SetField(playerMovement, "ground", mask);
    }

    private void DefineInputs(bool right, bool left, bool jump) {
        playerMovement.right = right;
        playerMovement.left = left;
        playerMovement.jump = jump;
    }
}

public class PlayerMovementForTest : PlayerMovement
{
    internal bool right;
    internal bool left;
    internal bool jump;

    protected override bool InputKey(KeyCode key) {
        if (key == Bindings.BindingsDic["Left"]) {
            return left;
        }
        else if (key == Bindings.BindingsDic["Right"]) {
            return right;
        }
        return false;
    }

    protected override bool InputKeyDown(KeyCode key) {
        if(key == Bindings.BindingsDic["Jump"]) {
            return jump;
        }
        return false;
    }
}