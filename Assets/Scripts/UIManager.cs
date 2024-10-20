using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject gameUI;
    public GameObject pauseUI;
    public GameObject howUI;

    void Start()
    {
        LoadGameUI();
    }

    public void LoadGameUI()
    {
        gameUI.SetActive(true);
        pauseUI.SetActive(false);
        howUI.SetActive(false);
    }
    public void LoadPauseUI()
    {
        gameUI.SetActive(false);
        pauseUI.SetActive(true);
        howUI.SetActive(false);
    }

    public void LoadHowUI()
    {
        gameUI.SetActive(false);
        pauseUI.SetActive(false);
        howUI.SetActive(true);
    }

}
