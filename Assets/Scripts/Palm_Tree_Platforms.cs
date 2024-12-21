using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palm_Tree_Platforms : MonoBehaviour
{
    [Header("Rotation References")]
    public Transform RotationCenter;
    public float RotateSpeed;
    
    [Header("Private References")]
    private Quaternion originalRotation;
    private bool isPlayerInside;

    private void Start()
    {
        originalRotation = transform.rotation;
        isPlayerInside = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false;
        }
    }

    private void Update()
    {
        if (isPlayerInside)
        {
            // Calculate the target rotation only on the Z-axis
            Quaternion targetRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, RotationCenter.rotation.eulerAngles.z);

            // Calculate the rotation step
            float rotationStep = RotateSpeed * Time.deltaTime;

            // Rotate towards the target rotation
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationStep);
        }
        else
        {
            // Return to the original rotation
            transform.rotation = Quaternion.RotateTowards(transform.rotation, originalRotation, RotateSpeed * Time.deltaTime);
        }
    }
}
