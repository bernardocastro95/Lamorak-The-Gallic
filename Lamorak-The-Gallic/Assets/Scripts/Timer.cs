using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeLeft;
    public bool timeOn = false;
    public Text timeTxt;
    // Start is called before the first frame update
    void Start()
    {
        timeOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeOn)
        {
            if(timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                timerUpdate(timeLeft);
            }
            else
            {
                Debug.Log("Time is up");
                timeLeft = 0;
                timeOn = false;
            }
        }
    }

    void timerUpdate(float current)
    {
        current += 1;

        float mins = Mathf.FloorToInt(current / 60);
        float secs = Mathf.FloorToInt(current % 60);

        timeTxt.text = string.Format("{0:00} : {1:00}", mins, secs);
    }
}
