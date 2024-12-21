using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge_Drop : MonoBehaviour
{
    [Header("Animator References")]
    public Animator BridgeSupportAnimOne;
    public Animator BridgeSupportAnimTwo;
    public Animator BreakPointAnimOne;
    public Animator BreakPointAnimTwo;

    [Header("Timer References")]
    public float StartTime;
    public bool TimerStart;
    private float CurrentTime;

    [Header("Sound References")]
    public AudioSource SoundMaker;
    public AudioClip Splitting;
    public AudioClip Breaking;
    public float SplittingSound;
    public float BreakingSound;

    [Header("Private References")]
    private bool HasBreakPlayed = false;
    private bool HasSplittingPlayed = false;

    private void Start()
    {
        CurrentTime = StartTime;
        TimerStart = false;
    }

    private void Update()
    {
        if (TimerStart == true)
        {
            CurrentTime -= Time.deltaTime;
        }

        if (CurrentTime <= 0)
        {
            BreakPointAnimOne.SetBool("Fall_Drop", true);
            BreakPointAnimTwo.SetBool("Fall_Drop", true);

            BreakPointAnimOne.SetBool("Slight_Drop", false);
            BreakPointAnimTwo.SetBool("Slight_Drop", false);

            if (HasBreakPlayed == false)
            {
                SoundMaker.PlayOneShot(Breaking, BreakingSound);

                HasBreakPlayed = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TimerStart = true;

            BridgeSupportAnimOne.SetBool("Drop_Beam", true);
            BridgeSupportAnimTwo.SetBool("Drop_Beam", true);

            BreakPointAnimOne.SetBool("Slight_Drop", true);
            BreakPointAnimTwo.SetBool("Slight_Drop", true);

            if (HasSplittingPlayed == false)
            {
                SoundMaker.PlayOneShot(Splitting, SplittingSound);

                HasSplittingPlayed = true;
            }
        }
    }
}
