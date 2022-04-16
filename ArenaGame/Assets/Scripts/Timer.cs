using UnityEngine;
using System;
public class Timer : MonoBehaviour
{
    public float time = 0;
    bool isCountingDown = false;

    void Update()
    {
        if (isCountingDown)
        {
            time += Time.deltaTime;
        }
    }
    public void StartCountDown()
    {
        isCountingDown = true;
    }
    public void StopCountDown()
    {
        isCountingDown = false;
    }
    public void ResetTimer()
    {
        time = 0;
    }
    public float GetTime()
    {
        return time;
    }
    public string GetTimeInClockFormat()
    {

       string t= TimeSpan.FromSeconds(time).ToString("mm\\:ss\\:ff");
        return t;
       
    }
  
}

