using Cinemachine;
using System.Collections.Generic;
using UnityEngine;

public class TestCameraChange : MonoBehaviour
{
    private List<CinemachineVirtualCamera> cameras = new List<CinemachineVirtualCamera> { };
    public CinemachineVirtualCamera cam = null;
    [SerializeField] CinemachineVirtualCamera playerCam;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!cameraTag(other.gameObject))
            return;
        assignNewCamera(other.gameObject);
        CameraManager.SwitchCamera(cam);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(!cameraTag(other.gameObject)) return;
        CameraManager.SwitchCamera(playerCam);
        other.GetComponent<Transform>().root.gameObject.SetActive(false);
    }

    public void BackToPlayerCamera()
    {
        CameraManager.SwitchCamera(playerCam);
    }

    bool cameraTag(GameObject Go)
    {
        if (Go.tag == "transitionCam")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void assignNewCamera(GameObject go)
    {
        CinemachineVirtualCamera camera = go.GetComponentInParent<CinemachineVirtualCamera>();

        for (int i = 0; i < cameras.Count; i++)
        {
            if (camera == cameras[i])
            {
                cam = camera;
                return;
            }
        }
        cameras.Add(camera);
        cam = camera;
        camera = null;
        return;
    }
}
