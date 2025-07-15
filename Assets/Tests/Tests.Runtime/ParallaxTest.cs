using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ParallaxTest : RuntimeTestBase
{
    private GameObject camera;
    private GameObject background;
    private Parallax parallax;
    private float parallaxSpeed = 0.5f;

    [UnitySetUp]
    public IEnumerator Setup(){
        CreateCamera();
        CreateBackground();
        CreateParallax();
        yield return new WaitForSeconds(0.1f);
    }

    [UnityTest]
    public IEnumerator Parallax_MoveBackground_Test(){
        float inicialPosition = background.transform.position.x;
        camera.transform.position = new Vector3(1f, 0, 0);
        yield return new WaitForSeconds(0.1f);
        float expectedPositionX = inicialPosition + camera.transform.position.x * parallaxSpeed;
        Assert.That(background.transform.position.x, Is.EqualTo(expectedPositionX).Within(0.01f));
    }

    [UnityTest]
    public IEnumerator Parallax_BoundsLeft_Test(){
        camera.transform.position = new Vector3(-100, 0, 0);
        float expectedPositionX = camera.transform.position.x - HalfBackgroundLength() + HalfCameraLenght();
        yield return new WaitForSeconds(0.1f);
        Assert.That(background.transform.position.x, Is.EqualTo(expectedPositionX).Within(0.01f));
    }

    [UnityTest]
    public IEnumerator Parallax_BoundsRight_Test(){
        camera.transform.position = new Vector3(100, 0, 0);
        float expectedPositionX = camera.transform.position.x + HalfBackgroundLength() - HalfCameraLenght();
        yield return new WaitForSeconds(0.1f);
        Assert.That(background.transform.position.x, Is.EqualTo(expectedPositionX).Within(0.01f));
    }

    private void CreateCamera(){
        camera = new GameObject("Main Camera");
        camera.AddComponent<Camera>();
        camera.tag = "MainCamera";
    }

    private void CreateBackground(){
        background = new GameObject("Background");
        SpriteRenderer spriteRenderer = background.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = Sprite.Create(Texture2D.whiteTexture, new Rect(0,0,1,1), new Vector2(0.5f, 0.5f));
        background.transform.localScale = new Vector3(2000f, 5f, 1f); //2000 pixels de sprite || 20 unidades unity
    }

    private void CreateParallax(){
        parallax = background.AddComponent<Parallax>();
        parallax.parallaxSpeed = parallaxSpeed;
    }

    private float HalfBackgroundLength(){
        return background.GetComponent<SpriteRenderer>().bounds.size.x/2;
    }

    private float HalfCameraLenght(){
        return Camera.main.orthographicSize * Camera.main.aspect;
    }
}
