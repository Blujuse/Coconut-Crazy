using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [Header("Movement References")]
    public float rollForce = 10f;
    public float maxRollSpeed = 5f;
    public float rotationSpeed = 100f;

    [Header("Jumping References")]
    public float jumpForce = 5f;
    public float AirDrag = 1f;
    public LayerMask WhatIsGround;
    public float PlayerHeight;

    [Header("Menu References")]
    public bool LockPosition;

    [Header("Sound References")]
    public AudioSource SoundMaker;
    public AudioClip JumpSound;
    public AudioClip GroundHitSound;

    [Header("Private References")]
    private Rigidbody rb;
    private bool isGrounded;
    [SerializeField] public Vector3 PlayerStartPos;
    [SerializeField] private Vector3 PlayerXPos;
    [HideInInspector] public bool LockXPos;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = maxRollSpeed;

        PlayerStartPos = transform.position;

        LockPosition = true;
    }

    void Update()
    {
        // ground check
        Debug.DrawRay(transform.position, Vector3.down * (PlayerHeight * 0.5f + 0.3f), Color.red);

        isGrounded = Physics.Raycast(transform.position, Vector3.down, PlayerHeight * 0.5f + 0.3f, WhatIsGround);

        if (isGrounded == true)
        {
            rb.drag = 1f;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();

            SoundMaker.PlayOneShot(JumpSound, 0.3f);
        }

        if (LockPosition == true)
        {
            transform.position = PlayerStartPos;
        }

        if (LockXPos == true)
        {
            Vector3 newPosition = transform.position;
            newPosition.x = PlayerXPos.x;
            transform.position = newPosition;
        }

    }

    void FixedUpdate()
    {
        if (LockPosition == false && LockXPos == false)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");

            Vector3 movement = new Vector3(moveHorizontal, 0f).normalized;
            rb.AddForce(movement * rollForce);

            PlayerXPos = transform.position;

            if (movement != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(movement, transform.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.fixedDeltaTime);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts.Length > 0)
        {
            ContactPoint contact = collision.contacts[0];
            if (Vector3.Dot(contact.normal, Vector3.up) > 0.7f)
            {
                isGrounded = true;
                rb.drag = 1f;
            }
        }

        if (LockPosition == false)
        {
            SoundMaker.PlayOneShot(GroundHitSound, 0.3f);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
        rb.drag = AirDrag;
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }
}