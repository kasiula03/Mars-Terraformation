using System;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public event Action OnNewDay;
    
    public float DayLong = 60f;
    public int TimeMultiplier = 1;
    public float CurrentTime = 0;
    public string TimeStr;

    private void Update()
    {
        CurrentTime += (Time.deltaTime / DayLong) * TimeMultiplier;

        TimeSpan t = TimeSpan.FromSeconds(CurrentTime * 3600 * 24);
        TimeStr = $"{t.Hours:D2}:{t.Minutes:D2}:{t.Seconds:D2}";

        if (CurrentTime > 1)
        {
            StartNewDay();
        }

        transform.rotation = Quaternion.Euler(CurrentTime * 360, 0, 0);
    }

    private void StartNewDay()
    {
        Debug.Log("New Day!!");
        CurrentTime = 0;
        OnNewDay?.Invoke();
    }
}