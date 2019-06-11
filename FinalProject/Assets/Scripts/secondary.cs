using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class secondary : MonoBehaviour
{
    public Text timerText;
    public static float secondsCount;
    public static int minuteCount;
    public static int hourCount;
    // Start is called before the first frame updat

    // Update is called once per frame
    void Update()
    {
        UpdateTimerUI();
    }

    public void UpdateTimerUI()
    {
        //set timer UI
        timer.secondsCount += Time.deltaTime;
        timerText.text = timer.hourCount + "h:" + timer.minuteCount + "m:" + (int)timer.secondsCount + "s";
        if (timer.secondsCount >= 60)
        {
            timer.minuteCount++;
            timer.secondsCount = 0;
        }
        else if (timer.minuteCount >= 60)
        {
            timer.hourCount++;
            timer.minuteCount = 0;
        }
    }
}