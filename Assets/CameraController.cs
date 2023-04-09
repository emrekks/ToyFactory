using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour 
{
    public Transform target;      // Reference to the target transform

    public float distance;
    
    public float smoothTime = 0.3f;      // Smooth time for camera movement
   
    public float yOffset = 2.0f;      // Y offset for camera position

    private Vector3 velocity = Vector3.zero;      // Velocity for camera movement

    void LateUpdate () 
    {
        Vector3 targetPosition = target.TransformPoint(new Vector3(0, yOffset, distance));      // Get the target position with an offset
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);      // Smoothly move the camera to the target position
    }
}
