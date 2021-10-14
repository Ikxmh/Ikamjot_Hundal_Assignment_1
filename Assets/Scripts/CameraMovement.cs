using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform moveThreshold;


    // Update is called once per frame
    void Update()
    {
        CameraFollows();
    }

    private void CameraFollows()
    {
        
    }
}
