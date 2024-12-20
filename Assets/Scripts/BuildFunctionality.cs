﻿using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuildFunctionality : MonoBehaviour
{
    void Update()
    {
        //close app on build
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
        //reload scene
        if (Input.GetKeyDown(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager
                .GetActiveScene().name);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}