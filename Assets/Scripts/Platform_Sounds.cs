using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Sounds : MonoBehaviour
{
    [Header("Sound References")]
    public AudioSource SoundMaker;

    public void FlowingSoundStart()
    {
        SoundMaker.Play();
    }

    public void FlowingSoundEnd()
    {
        SoundMaker.Stop();
    }
}
