using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Player_Movement PlayerScript;

    private void OnTriggerEnter(Collider other)
    {
        PlayerScript.PlayerStartPos = PlayerScript.transform.position;
    }

}
