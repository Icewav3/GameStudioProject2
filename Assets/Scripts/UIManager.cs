using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject gameUI;
    public GameObject pauseUI;
    public GameObject howUI;
    public GameObject winUI;
    public GameObject loseUI;

    void Start()
    {
        LoadUI(gameUI);
    }

    public void LoadUI(GameObject uiToLoad)
    {
        gameUI.SetActive(uiToLoad == gameUI);
        pauseUI.SetActive(uiToLoad == pauseUI);
        howUI.SetActive(uiToLoad == howUI);
        winUI.SetActive(uiToLoad == winUI);
        loseUI.SetActive(uiToLoad == loseUI);
    }
    public void LoadGameUI()
    {
        LoadUI(gameUI);
    }
    public void LoadPauseUI()
    {
        LoadUI(pauseUI);
    }
    public void LoadHowUI()
    {
        LoadUI(howUI);
    }
    public void LoadWinUI()
    {
        LoadUI(winUI);
    }
    public void LoadLoseUI()
    {
        LoadUI(loseUI);
    }
}
