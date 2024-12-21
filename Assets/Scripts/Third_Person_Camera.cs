using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Third_Person_Camera : MonoBehaviour
{
    [Header("Player References")]
    public Transform orientation;
    public Transform CamFollow;
    public Transform CoconutModel;
    public Rigidbody rb;

    [Header("Camera Refrences")]
    public float RotationSpeed;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rb = CamFollow.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 viewDir = CamFollow.position - new Vector3(transform.position.x, CamFollow.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (inputDir != Vector3.zero)
        {
            CoconutModel.forward = Vector3.Slerp(CoconutModel.forward, inputDir.normalized, Time.deltaTime * RotationSpeed);
        }
    }
}
