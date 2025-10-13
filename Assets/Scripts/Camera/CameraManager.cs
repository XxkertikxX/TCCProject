using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public static List<CinemachineVirtualCamera> cameras = new List<CinemachineVirtualCamera>();

    public static CinemachineVirtualCamera Activecamera = null;

    public static bool IsActiveCamera(CinemachineVirtualCamera camera)
    {
        return Activecamera == camera;
    }

    public static void SwitchCamera(CinemachineVirtualCamera newCamera)
    {
        newCamera.Priority = 10;
        Activecamera = newCamera;

        foreach (var cam in cameras)
        {
            if (cam != newCamera)
            {
                cam.Priority = 0;
            }
        }
    }

    public static void Register(CinemachineVirtualCamera cam)
    {
        cameras.Add(cam);
    }
    public static void Unregister(CinemachineVirtualCamera cam)
    {
        cameras.Remove(cam);
    }
}
