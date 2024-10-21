using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStateManager : MonoBehaviour
{
    public float timeScale = 1.0f;//For testing only, so we can fast forward
    public static bool gameIsPaused;
    public static bool playerLost;

    public void Start()
    {
        playerLost = false;
        ResumeGame();
    }
    //For testing only
    public void Update()
    {
        if (!gameIsPaused)
        {
            Time.timeScale = timeScale;
        }
    }
    public void EnterMainScene()
    {
        SceneManager.LoadScene(1);
    }

    public void PauseGame()
    {
        gameIsPaused = true;
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        gameIsPaused = false;
        Time.timeScale = 1;
    }
}
