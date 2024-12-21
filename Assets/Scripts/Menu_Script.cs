using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Script : MonoBehaviour
{
    [Header("UI References")]
    public GameObject StartMenu;
    public GameObject EndMenu;
    public GameObject CreditsMenu;

    [Header("Player References")]
    public Player_Movement PlayerScript;

    [Header("Cam References")]
    public Two_Five_Cam CamScript;

    [Header("Trigger References")]
    public End_Trigger EndTriggerScript;

    [Header("Sound References")]
    public AudioSource SoundMaker;
    public AudioSource Victory;

    [Header("Private References")]
    private bool IsPlayerAtCredits = false;
    private bool HasVictorySoundPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        StartMenu.SetActive(true);
        EndMenu.SetActive(false);
        CreditsMenu.SetActive(false);
    }

    private void Update()
    {
        if (EndTriggerScript.EndTrigger == true)
        {
            if (IsPlayerAtCredits == false)
            {
                EndMenu.SetActive(true);
            }
            else
            {
                EndMenu.SetActive(false);
            }

            PlayerScript.LockXPos = true;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            if (HasVictorySoundPlayed == false)
            {
                Victory.Play();

                HasVictorySoundPlayed = true;
            }
        }      
    }

    public void StartButton()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        StartMenu.SetActive(false);

        PlayerScript.LockPosition = false;

        CamScript.HasPlayerStarted = true;

        SoundMaker.Play();
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(0);

        SoundMaker.Play();
    }

    public void CreditsButton()
    {
        CreditsMenu.SetActive(true);

        IsPlayerAtCredits = true;

        SoundMaker.Play();
    }

    public void QuitButton()
    {
        Application.Quit();

        Debug.Log("Quit Game");

        SoundMaker.Play();
    }
}
