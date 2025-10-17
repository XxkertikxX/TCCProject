using System.Collections;
using UnityEngine;
using Cinemachine;

public class LookCamera : MonoBehaviour
{
    private CinemachineVirtualCamera virtualCam;
    [SerializeField] private float lookOffset = 2f;
    private CinemachineFramingTransposer bodyConfigs;
    private Vector3 defaultOffset;
    public Coroutine coroutine;

    [Header("Tempo de segurar")]
    [SerializeField] private float timer = 0;
    [SerializeField] private float holdTime;

    private void Start()
    {
        virtualCam = GetComponent<CinemachineVirtualCamera>();
        bodyConfigs = virtualCam.GetCinemachineComponent<CinemachineFramingTransposer>();
        defaultOffset = bodyConfigs.m_TrackedObjectOffset;
    }

    private void Update()
    {
        float verticalInput = Input.GetAxisRaw("Vertical");

        if(verticalInput <= -0.2f || verticalInput >= 0.2f)
        {
            timer += Time.deltaTime;
            if(timer >= holdTime)
            {
                bodyConfigs.m_TrackedObjectOffset = (defaultOffset * verticalInput)+ new Vector3(0, lookOffset * verticalInput, 0);
            }
        }
        else
        {
            timer = 0;
            bodyConfigs.m_TrackedObjectOffset = defaultOffset;
        }

    }
}
