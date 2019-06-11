using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Best_time : MonoBehaviour
{
    private float secondsCount = 100;
    private int minuteCount = 100;
    // Start is called before the first frame update
    void Start()
    {
           
        if (minuteCount >= timer.minuteCount)
        {
            minuteCount = timer.minuteCount;
            secondsCount = timer.secondsCount;
            GetComponent<TextMesh>().text = minuteCount + "m:" + (int) secondsCount + "s";
        }
        else if (minuteCount == timer.minuteCount)
        {
            if(secondsCount >= timer.secondsCount)
            {
                minuteCount = timer.minuteCount;
                secondsCount = timer.secondsCount;
                GetComponent<TextMesh>().text = minuteCount + "m:" + (int)secondsCount + "s";
            }

        }
    }
}
