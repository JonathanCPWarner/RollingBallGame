using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;

    public Vector3 velocity;
    public float smoothSpeed = 10f;
    public Vector3 offset;

    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.SmoothDamp (transform.position, desiredPosition, ref velocity, Time.deltaTime * smoothSpeed);
        target.position = smoothedPosition;
    }
    
}
