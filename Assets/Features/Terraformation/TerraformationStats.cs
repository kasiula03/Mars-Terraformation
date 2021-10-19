using System;
using UnityEngine;

public class TerraformationStats : MonoBehaviour
{
    public event Action OnStatsChanged;
    public event Action OnGameFinished;
    
    public int CurrentOceans = 0;
    public int CurrentOxygenPercent = 0;
    public int CurrentTemp = -30;

    private int _requiredOceans = 2;
    private int _requiredOxygen = 12;
    private int _requiredTemp = 8;

    public bool IsTerraformed => CurrentOceans == _requiredOceans && CurrentOxygenPercent == _requiredOxygen &&
                                 CurrentTemp == _requiredTemp;

    public void AddTemp(int temp)
    {
        CurrentTemp += temp;
        CurrentTemp = Math.Min(CurrentTemp, _requiredTemp);
        OnStatsChanged?.Invoke();
        CheckGameFinish();
    }
    
    public void AddOxygen(int oxygen)
    {
        CurrentOxygenPercent += oxygen;
        CurrentOxygenPercent = Math.Min(CurrentOxygenPercent, _requiredOxygen);
        OnStatsChanged?.Invoke();
        CheckGameFinish();
    }

    public void AddOcean(int ocean)
    {
        CurrentOceans += ocean;
        OnStatsChanged?.Invoke();
        CheckGameFinish();
    }
    
    private void CheckGameFinish()
    {
        if (IsTerraformed)
        {
            OnGameFinished?.Invoke();
        }
    }

}