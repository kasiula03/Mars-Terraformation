using System;
using UnityEngine;

public class ThermometerController : MonoBehaviour
{
    [SerializeField] private ObjectNumber _objectNumber;
    [SerializeField] private Transform _thermometerFill;

    private TerraformationStats _terraformationStats;
    private Vector3 _startingPoint;

    private void Start()
    {
        _startingPoint = _objectNumber.transform.position;
        _terraformationStats = FindObjectOfType<TerraformationStats>();
        _terraformationStats.OnStatsChanged += UpdateTemp;

        UpdateTemp();
    }

    private void UpdateTemp()
    {
        Color color = _terraformationStats.CurrentTemp >= 2 ? Color.red : Color.blue;
        _objectNumber.Create(_terraformationStats.CurrentTemp, color, true);
        float percent = (30 + _terraformationStats.CurrentTemp) / 38f; // -30 is min temp
        _objectNumber.transform.position = _startingPoint + (new Vector3(0, 2.5f, 0)) * percent;
        _thermometerFill.localScale = new Vector3(1, 1 * percent, 1);
    }
}