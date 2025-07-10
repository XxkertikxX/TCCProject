using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ParallaxTest
{
    private GameObject camera;
    private GameObject background;
    private Parallax parallax;

    [UnitySetUp]
    public IEnumerator Setup(){
        CreateCamera();
        CreateBackground();
        CreateParallax();
        yield return new WaitForEndOfFrame();
    }

    [UnityTest]
    public IEnumerator Parallax_MoveBackground_Test(){
        Debug.Log(background.transform.position.x);
        camera.transform.position = new Vector3(5f, 0, 0);
        yield return new WaitForSeconds(1);
        float expectedPositionX = parallax.inicialPosition + camera.transform.position.x * parallax.parallaxSpeed;
        Debug.Log(background.transform.position.x);
        Assert.That(background.transform.position.x, Is.EqualTo(4.727074f).Within(0.01f));
    }

    [UnityTest]
    public IEnumerator Parallax_BoundsLeft_Test(){
        camera.transform.position = new Vector3(-2.23f, 0, 0);
        yield return new WaitForSeconds(1);
        Assert.That(background.transform.position.x, Is.EqualTo(-3.34f).Within(0.05f));
    }

    [UnityTest]
    public IEnumerator Parallax_BoundsRight_Test(){
        camera.transform.position = new Vector3(2.23f, 0, 0);
        yield return new WaitForSeconds(1);
        Assert.That(background.transform.position.x, Is.EqualTo(3.34f).Within(0.05f));
    }

    [UnityTearDown]
    public IEnumerator TearDown(){
        GameObject.Destroy(camera);
        GameObject.Destroy(background);
        yield return new WaitForEndOfFrame();
    }

    private void CreateCamera(){
        camera = new GameObject("Main Camera");
        camera.AddComponent<Camera>();
        camera.tag = "MainCamera";
        camera.transform.position = Vector3.zero;
    }

    private void CreateBackground(){
        background = new GameObject("Background");
        SpriteRenderer spriteRenderer = background.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = Sprite.Create(Texture2D.whiteTexture, new Rect(0,0,1,1), new Vector2(0.5f, 0.5f));
        background.transform.localScale = new Vector3(20f, 5f, 1f);
        background.transform.position = Vector3.zero;
    }

    private void CreateParallax(){
        parallax = background.AddComponent<Parallax>();
        parallax.parallaxSpeed = 0.5f;
    }
}
