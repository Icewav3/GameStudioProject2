using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    public TMP_Text timerDisplay;
    [SerializeField]
    private float countdownDuration = 180f;
    private float timeRemaining;

    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = countdownDuration;
        timerDisplay.text = timeRemaining.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerDisplay();
        }

        else
        {
            timeRemaining = 0;
        }

    }

    public void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);

        string timeToString = string.Format("{0:D1}:{1:D2}", minutes, seconds);
        timerDisplay.text = timeToString;

    }
}
