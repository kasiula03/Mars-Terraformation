using System;
using UnityEngine;

public class ObjectNumber : MonoBehaviour
{
	[SerializeField] private Transform _hundreds;
	[SerializeField] private Transform _dozens;
	[SerializeField] private Transform _units;
	[SerializeField] private NumberPrefabs _numberPrefabs;

	private void Awake()
	{
		WaveTween.Tween(transform);
	}

	public void Create(int number, Color color)
	{
		Destroy();

		int hundreds = number / 100;
		int dozens = (number - (hundreds * 100)) / 10;
		int units = number - (hundreds * 100) - (dozens * 10);

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
	}

	public void Destroy()
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
	}

	private void CreateNumber(GameObject hundredPrefab, Transform parent, Color color)
	{
		GameObject obj = Instantiate(hundredPrefab, parent);
		obj.GetComponent<MeshRenderer>().material.color = color;
	}
}