using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kill_Box : MonoBehaviour
{
    [Header("Cube References")]
    public Reset_Cube_Pos Cube;

    [Header("Player References")]
    public Player_Movement PlayerScript;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerScript.transform.position = PlayerScript.PlayerStartPos;
        }
        
        if (other.CompareTag("Cube"))
        {
            Cube.transform.position = Cube.CubePos;
        }
    }
}
