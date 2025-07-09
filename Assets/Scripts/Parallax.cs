using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float parallaxSpeed;
    
    private Transform cam;
    private float inicialPosition;
    private float backgroundLength;

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
        if (offScreenBackgroundLeft()) {
            RepositionBackground(backgroundLength);
        }
        else if (offScreenBackgroundRight()) {
            RepositionBackground(-backgroundLength);
        }
    }

    private bool offScreenBackgroundLeft(){
        return CamBackgroundPos() > inicialPosition + backgroundLength;
    }

    private bool offScreenBackgroundRight(){
        return CamBackgroundPos() < inicialPosition - backgroundLength;
    }

    private void RepositionBackground(float offSet) {
        inicialPosition += offSet;
    }

    private float CamBackgroundPos() {
        return cam.position.x * (1 - parallaxSpeed);
    }
}
