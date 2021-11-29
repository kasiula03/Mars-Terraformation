using System;
using UnityEngine;

public class ThermometerController : MonoBehaviour
{
    [SerializeField] private ObjectNumber _objectNumber;
    [SerializeField] private MeshRenderer _fillMaterial;

    private TerraformationStats _terraformationStats;
    private Vector3 _startingPoint;

    private MaterialPropertyBlock _percentPropertyBlock;
    private static readonly int FillPercent = Shader.PropertyToID("_FillPercent");

    private void Start()
    {
        _percentPropertyBlock = new MaterialPropertyBlock();
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
        
        
        _fillMaterial.GetPropertyBlock(_percentPropertyBlock);
        _percentPropertyBlock.SetFloat(FillPercent, percent);
        _fillMaterial.SetPropertyBlock(_percentPropertyBlock);
    }
}