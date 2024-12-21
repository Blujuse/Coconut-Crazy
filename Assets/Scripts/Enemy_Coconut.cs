using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy_Coconut : MonoBehaviour
{
    [Header("Enemy References")]
    public Transform startPoint;
    public Transform endPoint;
    public float rollForce = 10f;
    public float maxRollSpeed = 5f;
    public float rotationSpeed = 100f;

    [Header("Player References")]
    public Player_Movement PlayerScript;

    [Header("Private References")]
    private Rigidbody rb;
    private Transform currentTarget;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentTarget = endPoint;
    }

    private void FixedUpdate()
    {
        Vector3 direction = (currentTarget.position - transform.position).normalized;

        // Calculate desired velocity based on rollForce
        Vector3 desiredVelocity = direction * rollForce;

        // Adjust desired velocity based on the current velocity
        desiredVelocity -= rb.velocity;

        // Limit maximum roll speed
        if (desiredVelocity.magnitude > maxRollSpeed)
        {
            desiredVelocity = desiredVelocity.normalized * maxRollSpeed;
        }

        // Apply the force to the rigidbody
        rb.AddForce(desiredVelocity, ForceMode.VelocityChange);

        Quaternion toRotation = Quaternion.LookRotation(direction, transform.up);
        rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.fixedDeltaTime));

        // Check if reached the target point
        if (Vector3.Distance(transform.position, currentTarget.position) <= 0.1f)
        {
            // Switch target point
            if (currentTarget == startPoint)
                currentTarget = endPoint;
            else
                currentTarget = startPoint;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerScript.transform.position = PlayerScript.PlayerStartPos;
        }
    }
}
