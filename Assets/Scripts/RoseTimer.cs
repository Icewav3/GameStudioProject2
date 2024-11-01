using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoseTimer : MonoBehaviour
{
    public float defaultTime = 10.0f;
    private float countDownTime;
    public bool timerStarted;
    public Color emptyColor;
    public Color nearFullColor;
    public Color defaultColor;
    public Image bagImage;



    // Start is called before the first frame update
    void Start()
    {
        timerStarted = false;
        countDownTime = 0;
        emptyColor = new Color(230.0f / 255.0f, 100.0f / 255.0f, 100.0f / 255.0f, 40.0f / 255.0f);
        nearFullColor = new Color(255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f, 160.0f / 255.0f);
        defaultColor = new Color(255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f);
        bagImage.color = defaultColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerStarted)
        {
            countDownTime += Time.deltaTime;
            LerpColor();
            if (countDownTime >= defaultTime)
            {
                timerStarted = false;
                countDownTime = 0;
                bagImage.color = defaultColor;
            }
        }
    }

    private void LerpColor()
    {
        bagImage.color = Color.Lerp(emptyColor, nearFullColor, countDownTime / defaultTime);
    }
}
