using UnityEngine;
using UnityEngine.Tilemaps;
public class Parallax : MonoBehaviour
{
    [Range (0, 1)] [SerializeField] private float parallaxSpeed;

    private float inicialPosition;
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
            RepositionBackground(-backgroundLength);
        }
        if (OffScreenBackgroundRight()) {
            RepositionBackground(backgroundLength);
        }
    }

    private void RepositionBackground(float offset) {
        transform.position += new Vector3(offset, 0, 0);
        inicialPosition = transform.position.x - Distance();
    }


    private bool OffScreenBackgroundLeft() {
        return BackgroundEdge(-backgroundLength) > CameraEdge(-HalfCameraWidth());
    }

    private bool OffScreenBackgroundRight() {
        return BackgroundEdge(backgroundLength) < CameraEdge(HalfCameraWidth());
    }

    private float BackgroundEdge(float backgroundX){
        return transform.position.x + backgroundX * 3/2;
    }

    private float CameraEdge(float halfCameraWidth){
        return cam.position.x + halfCameraWidth;
    }

    private float HalfCameraWidth(){
        return Camera.main.orthographicSize * Camera.main.aspect;
    }
}