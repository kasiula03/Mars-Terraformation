using System;
using UnityEngine;

public class ObjectNumber : MonoBehaviour
{
    [SerializeField] private Transform _sign;
    [SerializeField] private Transform _hundreds;
    [SerializeField] private Transform _dozens;
    [SerializeField] private Transform _units;
    [SerializeField] private NumberPrefabs _numberPrefabs;
    [SerializeField] private bool _animate = true;

    private void Awake()
    {
        if (_animate)
        {
            WaveTween.Tween(transform);
        }
    }

    public void Create(int number, Color color, bool withSign = false)
    {
        Destroy();

        int hundreds = number / 100;
        int dozens = (number - (hundreds * 100)) / 10;
        int units = number - (hundreds * 100) - (dozens * 10);

        if (number < 0)
        {
            withSign = true;
            hundreds = Math.Abs(hundreds);
            dozens = Math.Abs(dozens);
            units = Math.Abs(units);
        }

        if (hundreds > 0)
        {
            GameObject hundredPrefab = _numberPrefabs.GetPrefab(hundreds);
            CreateNumber(hundredPrefab, _hundreds, color);
            GameObject dozenPrefab = _numberPrefabs.GetPrefab(dozens);
            CreateNumber(dozenPrefab, _dozens, color);
            GameObject unitPrefab = _numberPrefabs.GetPrefab(units);
            CreateNumber(unitPrefab, _units, color);
        }
        else if (dozens > 0)
        {
            GameObject dozenPrefab = _numberPrefabs.GetPrefab(dozens);
            CreateNumber(dozenPrefab, _dozens, color);
            GameObject unitPrefab = _numberPrefabs.GetPrefab(units);
            CreateNumber(unitPrefab, _units, color);
        }
        else
        {
            GameObject unitPrefab = _numberPrefabs.GetPrefab(units);
            CreateNumber(unitPrefab, _units, color);
        }

        if (withSign)
        {
            GameObject signPrefab = _numberPrefabs.GetSignPrefab(number >= 0);
            CreateNumber(signPrefab, _sign, color);
        }
    }

    private void Destroy()
    {
        if (_hundreds.childCount > 0)
        {
            DestroyImmediate(_hundreds.GetChild(0).gameObject);
        }

        if (_dozens.childCount > 0)
        {
            DestroyImmediate(_dozens.GetChild(0).gameObject);
        }

        if (_units.childCount > 0)
        {
            DestroyImmediate(_units.GetChild(0).gameObject);
        }

        if (_sign != null && _sign.childCount > 0)
        {
            DestroyImmediate(_sign.GetChild(0).gameObject);
        }
    }

    private void CreateNumber(GameObject prefab, Transform parent, Color color)
    {
        GameObject obj = Instantiate(prefab, parent);
        MeshRenderer meshRenderer = obj.GetComponent<MeshRenderer>();
        if (meshRenderer)
        {
            meshRenderer.material.color = color;
        }
        else
        {
            foreach (MeshRenderer childRenderer in obj.GetComponentsInChildren<MeshRenderer>())
            {
                childRenderer.material.color = color;
            }
        }
    }
}