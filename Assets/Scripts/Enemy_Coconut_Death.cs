using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_Coconut_Death : MonoBehaviour
{
    [Header("Enemy References")]
    public Transform EnemyCoconutPos;
    public GameObject EnemyCoconutObj;

    [Header("Position References")]
    public float YValue;

    [Header("Player References")]
    public GameObject Player;
    public Player_Movement PlayerScript;
    public Rigidbody PlayerRB;
    public float UpwardForce;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = EnemyCoconutPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(EnemyCoconutPos.position.x, YValue, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Apply upward force to the player
            PlayerRB.AddForce(Vector3.up * UpwardForce, ForceMode.Impulse);

            Destroy(EnemyCoconutObj);
            Destroy(this.gameObject);

            PlayerScript.SoundMaker.PlayOneShot(PlayerScript.JumpSound, 0.3f);
        }
    }
}
