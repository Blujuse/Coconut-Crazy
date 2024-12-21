using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End_Trigger : MonoBehaviour
{
    [Header("Private References")]
    [HideInInspector] public bool EndTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EndTrigger = true;
        }
    }
}
