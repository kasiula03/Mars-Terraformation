using System;
using UnityEngine;

public class BankController : MonoBehaviour
{
	[SerializeField] private Transform _hundreds;
	[SerializeField] private Transform _dozens;
	[SerializeField] private Transform _units;

	[SerializeField] private NumberPrefabs _numberPrefabs;
	[SerializeField] private PlayerResources _playerResources;

	private void Start()
	{
		_playerResources.OnResourcesChanged += UpdateNumbers;
		UpdateNumbers();
	}

	private void UpdateNumbers()
	{
		if (_hundreds.childCount > 0)
		{
			Destroy(_hundreds.GetChild(0).gameObject);
		}

		if (_dozens.childCount > 0)
		{
			Destroy(_dozens.GetChild(0).gameObject);
		}

		if (_units.childCount > 0)
		{
			Destroy(_units.GetChild(0).gameObject);
		}

		int goldAmount = _playerResources.Currencies[PlayerResources.Currency.GOLD];
		int hundreds = goldAmount / 100;
		int dozens = (goldAmount - (hundreds * 100)) / 10;
		int units = goldAmount - (hundreds * 100) - (dozens * 10);

		if (hundreds > 0)
		{
			GameObject hundredPrefab = _numberPrefabs.GetPrefab(hundreds);
			CreateNumber(hundredPrefab, _hundreds);
			GameObject dozenPrefab = _numberPrefabs.GetPrefab(dozens);
			CreateNumber(dozenPrefab, _dozens);
			GameObject unitPrefab = _numberPrefabs.GetPrefab(units);
			CreateNumber(unitPrefab, _units);
		}
		else if (dozens > 0)
		{
			GameObject dozenPrefab = _numberPrefabs.GetPrefab(dozens);
			CreateNumber(dozenPrefab, _dozens);
			GameObject unitPrefab = _numberPrefabs.GetPrefab(units);
			CreateNumber(unitPrefab, _units);
		}
		else
		{
			GameObject unitPrefab = _numberPrefabs.GetPrefab(units);
			CreateNumber(unitPrefab, _units);
		}
	}

	private void CreateNumber(GameObject hundredPrefab, Transform parent)
	{
		GameObject obj = Instantiate(hundredPrefab, parent);
		obj.GetComponent<MeshRenderer>().material.color = new Color(0.8313726F, 0.6862745F, 0.2156863F, 1f);
		WaveTween.Tween(obj.transform);
	}
}