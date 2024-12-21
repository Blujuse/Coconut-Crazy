using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu2 : MonoBehaviour
{
    private void OnCollisionEnter(Collision collisionInfo)
    {


        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
} 
