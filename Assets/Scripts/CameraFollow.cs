using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    Vector3 nextPosition;

    void Start()
    {
        nextPosition.z = transform.position.z;
    }

    void Update()
    {
        if(target)
        {
            nextPosition.x = target.position.x;
            nextPosition.y = target.position.y;

            transform.position = nextPosition;
        }
    }
}
