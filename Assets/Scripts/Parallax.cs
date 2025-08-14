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
        //backgroundLength = GetComponent<TilemapRenderer>().bounds.size.x;
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
            RepositionBackground(-backgroundLength, -HalfCameraWidth());
        }
        if (OffScreenBackgroundRight()) {
            RepositionBackground(backgroundLength, HalfCameraWidth());
        }
    }

    private void RepositionBackground(float offset, float cameraBounds) {
        transform.position += new Vector3(DistanceRepositionBackground(offset) - cameraBounds, 0, 0);
        inicialPosition = transform.position.x - Distance();
    }

    private float DistanceRepositionBackground(float backgroundLength){
        return cam.position.x - transform.position.x + backgroundLength/2;
    }

    private bool OffScreenBackgroundLeft() {
        return BackgroundEdge(-backgroundLength) > CameraEdge(-HalfCameraWidth());
    }

    private bool OffScreenBackgroundRight() {
        return BackgroundEdge(backgroundLength) < CameraEdge(HalfCameraWidth());
    }

    private float BackgroundEdge(float backgroundX){
        return transform.position.x + backgroundX / 2f;
    }

    private float CameraEdge(float halfCameraWidth){
        return cam.position.x + halfCameraWidth;
    }

    private float HalfCameraWidth(){
        return Camera.main.orthographicSize * Camera.main.aspect;
    }
}