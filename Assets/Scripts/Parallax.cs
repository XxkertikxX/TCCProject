using UnityEngine;

public class Parallax : MonoBehaviour
{
    Transform Cam;
    [SerializeField] float ParallaxSpeed;
    float InicialPosition;
    float backgroundLength;

    void Start() {
        Cam = Camera.main.transform;
        InicialPosition = transform.position.x;
        backgroundLength = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update() {
        ParallaxEffect();
        VerifyIfBackgroundOffScreen();
    }

    void ParallaxEffect() {
        transform.position = new Vector3(InicialPosition + Distance(), transform.position.y, transform.position.z);
    }

    float Distance() {
        return Cam.position.x * ParallaxSpeed;
    }

    void VerifyIfBackgroundOffScreen() {
        if (offScreenBackgroundLeft()) {
            RepositionBackground(backgroundLength);
        }
        else if (offScreenBackgroundRight()) {
            RepositionBackground(-backgroundLength);
        }
    }

    bool offScreenBackgroundLeft(){
        return CamBackgroundPos() > InicialPosition + backgroundLength;
    }

    bool offScreenBackgroundRight(){
        return CamBackgroundPos() < InicialPosition - backgroundLength;
    }

    void RepositionBackground(float offSet) {
        InicialPosition += offSet;
    }

    float CamBackgroundPos() {
        return Cam.position.x * (1 - ParallaxSpeed);
    }
}
