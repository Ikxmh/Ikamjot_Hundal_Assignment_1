using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineShake : MonoBehaviour
{
    public static CinemachineShake Instance { get; private set; }
    private CinemachineVirtualCamera cinemachineCam;
    private float shakeTimer;
    private void Awake()
    {
        Instance = this;
       cinemachineCam = GetComponent<CinemachineVirtualCamera>();
    }

    // calling/setting Noise in CinemachineVirtualCamera's Game Camera
    public void ShakeCamera(float shakeIntensity, float time)
    {
        CinemachineBasicMultiChannelPerlin cinemachineMCPerlin = 
            cinemachineCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cinemachineMCPerlin.m_AmplitudeGain = shakeIntensity;
        shakeTimer = time; 
    }


    // once called, it'll check the requirements 
    private void Update()
    {
        // shake the camera when greater than 0 
        if (shakeTimer > 0)
        {
            // decrease the time then
            shakeTimer -= Time.deltaTime;
            if (shakeTimer <= 0f)
            {
                // timer over
                // stop shaking
                CinemachineBasicMultiChannelPerlin cinemachineMCPerlin = 
                    cinemachineCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

                cinemachineMCPerlin.m_AmplitudeGain = 0f;
            }
            
        }
    }
}
