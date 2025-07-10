using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] internal float parallaxSpeed;
    internal float inicialPosition;

    private float backgroundLength;
    private Transform cam;
    private bool hasRepositioned = false;

    void Start() {
        cam = Camera.main.transform;
        inicialPosition = transform.position.x;
        backgroundLength = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update() {
        ParallaxEffect();
        VerifyIfBackgroundOffScreen();
        BackgroundInCamera();
    }

    private void ParallaxEffect() {
        transform.position = new Vector3(inicialPosition + Distance(), transform.position.y, transform.position.z);
    }

    private float Distance() {
        return cam.position.x * parallaxSpeed;
    }

    private void VerifyIfBackgroundOffScreen() {
        if (!hasRepositioned && OffScreenBackgroundLeft()) {
            RepositionBackground(-backgroundLength, CameraBoundsSize());
        }
        else if (!hasRepositioned && OffScreenBackgroundRight()) {
            RepositionBackground(backgroundLength, -CameraBoundsSize());
        }
    }

    private void RepositionBackground(float offset, float cameraBounds) {
        transform.position += new Vector3(offset + cameraBounds, 0, 0);
        inicialPosition = transform.position.x - Distance();
        hasRepositioned = true;
    }

    private void BackgroundInCamera(){
                if (!OffScreenBackgroundLeft() && !OffScreenBackgroundRight()) {
            hasRepositioned = false;
        }
    }
    private bool OffScreenBackgroundLeft() {
        return BackgroundEdge(-backgroundLength) > CameraEdge(-CameraBoundsSize());
    }

    private bool OffScreenBackgroundRight() {
        return BackgroundEdge(backgroundLength) < CameraEdge(CameraBoundsSize());
    }

    private float BackgroundEdge(float backgroundX){
        return transform.position.x + backgroundX / 2f;
    }

    private float CameraEdge(float cameraBoundsSize){
        return cam.position.x + cameraBoundsSize/2;
    }

    private float CameraBoundsSize(){
        return 2 * Camera.main.orthographicSize * Camera.main.aspect;
    }
}