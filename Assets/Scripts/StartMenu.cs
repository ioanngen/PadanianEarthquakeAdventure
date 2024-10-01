using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using StatHandle;
using UnityEditor;

public class StartMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Stats()
    {
        SceneManager.LoadScene(13);
    }

    public void Back()
    {
        SceneManager.LoadScene(0);
    }

}

