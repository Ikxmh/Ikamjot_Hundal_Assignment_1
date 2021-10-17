using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTriggers : MonoBehaviour
{
    [SerializeField] private GameObject cameraToTurnIn;
    [SerializeField] private GameObject cameraToZoomOut;

    public VirtualCamerasController vCamController;

    // transitions into
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            vCamController.TransitionCameraTo(cameraToTurnIn);
        }
    }

    // transitions out of 
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            vCamController.TransitionCameraTo(cameraToZoomOut);
        }
    }
}
