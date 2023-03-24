using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineShake : MonoBehaviour
{
    public static CinemachineShake Instance { get; private set; }
    private CinemachineVirtualCamera cmvc;
    private float shakeTimer;
    // Start is called before the first frame update

    private void Awake()
    {
        Instance = this;
        cmvc = GetComponent<CinemachineVirtualCamera>();
    }

    public void ShakeCamera(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin cmmcp =
            cmvc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cmmcp.m_AmplitudeGain = intensity;
        shakeTimer = time;
    }

    private void Update()
    {
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            if(shakeTimer <= 0f)
            {
                CinemachineBasicMultiChannelPerlin cmmcp =
                    cmvc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

                cmmcp.m_AmplitudeGain = 0f;
            }
        }
    }
}
