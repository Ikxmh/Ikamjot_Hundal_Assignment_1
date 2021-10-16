using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class VirtualCamerasController : MonoBehaviour
{
    [SerializeField] private List<GameObject> virtualCameras;

    // Start is called before the first frame update
    void Start()
    {
        virtualCameras.Clear();
        for(int i = 0; i < transform.childCount; i++)
        {
            virtualCameras.Add(transform.GetChild(i).gameObject);
        }
    }

    public void TransitionCameraTo(GameObject cameraTransitionTo)
    {
        foreach(GameObject camera in virtualCameras)
        {
            if(camera == cameraTransitionTo)
            {
                camera.GetComponent<CinemachineVirtualCamera>().Priority = 10;
            }
            else
            {
                camera.GetComponent<CinemachineVirtualCamera>().Priority = 5;
            }
        }
    }
}
