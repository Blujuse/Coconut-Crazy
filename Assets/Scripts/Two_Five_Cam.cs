using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Two_Five_Cam : MonoBehaviour
{
    [Header("Player References")]
    public Transform Player;
    public bool HasPlayerStarted = false;

    [Header("Position References")]
    public float YValue;
    public float XOffset;

    [Header("Rotation References")]
    public float XRotation;
    public float YRotation;

    [Header("Movement Settings")]
    public float smoothTime = 0.2f; // Adjust this value to control the smoothness of the camera movement
    private Vector3 velocity = Vector3.zero;

    private Vector3 targetPosition;

    private void Start()
    {
        // Set the initial target position to the current camera position
        targetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (HasPlayerStarted)
        {
            // Calculate the new target position
            targetPosition = new Vector3(Player.position.x + XOffset, YValue, transform.position.z);

            // Smoothly move the camera towards the target position using SmoothDamp
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

            transform.rotation = Quaternion.Euler(XRotation, YRotation, 0);
        }
    }
}
