using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] internal float parallaxSpeed;
    internal float inicialPosition;

    private float backgroundLength;
    private Transform cam;

    void Start() {
        cam = Camera.main.transform;
        inicialPosition = transform.position.x;
        backgroundLength = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update() {
        ParallaxEffect();
        VerifyIfBackgroundOffScreen();
    }

    private void ParallaxEffect() {
        transform.position = new Vector3(inicialPosition + Distance(), transform.position.y, transform.position.z);
    }

    private float Distance() {
        return cam.position.x * parallaxSpeed;
    }

    private void VerifyIfBackgroundOffScreen() {
        if (OffScreenBackgroundLeft()) {
            RepositionBackground(backgroundLength);
        }
        else if (OffScreenBackgroundRight()) {
            RepositionBackground(-backgroundLength);
        }
    }

    private bool OffScreenBackgroundLeft(){
        return CamBackgroundPos() > inicialPosition + backgroundLength;
    }

    private bool OffScreenBackgroundRight(){
        return CamBackgroundPos() < inicialPosition - backgroundLength;
    }

    private void RepositionBackground(float offSet) {
        inicialPosition += offSet;
    }

    private float CamBackgroundPos() {
        return cam.position.x * (1 - parallaxSpeed);
    }
}
