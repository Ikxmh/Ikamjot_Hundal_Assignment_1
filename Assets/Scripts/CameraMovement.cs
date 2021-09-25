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
        if (player.position.x > moveThreshold.position.x)
        {
            transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
        }
    }


}
