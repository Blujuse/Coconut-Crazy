using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset_Cube_Pos : MonoBehaviour
{
    [Header("Cube References")]
    public Vector3 CubePos;

    // Start is called before the first frame update
    void Start()
    {
        CubePos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
