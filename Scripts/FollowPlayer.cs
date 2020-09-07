using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    Transform playerTrans;

    public float camOffset;
    public float camYOffset;
    public float cameraSpeed;

    public Vector3 min;
    public Vector3 max;


    void Start()
    {
        playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Update()
    {
        SmootMovement();
        CameraMargin();
    }
    void SmootMovement()
    {
        Vector3 newPos = new Vector3(playerTrans.position.x - camOffset, playerTrans.position.y + camYOffset, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, newPos, cameraSpeed*Time.deltaTime);
    }

    void CameraMargin()
    {
        if(transform.position.x <= min.x)
        {
            transform.position = new Vector3(min.x, transform.position.y, transform.position.z);
        }
        if(transform.position.x >= max.x)
        {
            transform.position = new Vector3(max.x, transform.position.y, transform.position.z);
        }
        if (transform.position.x >= min.y)
        {
            transform.position = new Vector3(transform.position.x, min.y, transform.position.z);
        }
        if (transform.position.x >= max.y)
        {
            transform.position = new Vector3(transform.position.x, max.y, transform.position.z);
        }


    }
}
