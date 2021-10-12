using System;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public enum ConstructionType
{
	NONE,
	FOREST,
	CITY,
	OCEAN
}

public class ConstructionPlace : MonoBehaviour
{
	[SerializeField] private AvailableConstructions _availableConstructions;
	[SerializeField] private Transform _parent;
	[SerializeField] private Transform _constructionHammer;
	[SerializeField] private bool _oceanSpot;

	public bool IsEmpty => _construction == null;

	private GameObject _construction;
	private bool _isPlayerTriggered;
	private Sequence _hammerSequence;

	public void Start()
	{
		Quaternion rotation = _constructionHammer.localRotation;
		_hammerSequence = DOTween.Sequence();
		_hammerSequence.Append(_constructionHammer.DOLocalRotate(
			new Vector3(rotation.x, rotation.y + 360f, rotation.z), 2f,
			RotateMode.FastBeyond360).SetEase(Ease.Linear));
		_hammerSequence.SetLoops(-1);
		StopConstruction();

		if (_oceanSpot)
		{
			GetComponentInChildren<MeshRenderer>().material.color = Color.blue;
		}
	}

	public void Build(ConstructionType constructionType)
	{
		PlaceBuilding(constructionType);
		StopConstruction();
		_hammerSequence.Kill();
	}

	//TODO: Conditions for limited oceans
	public void PlaceBuilding(ConstructionType constructionType)
	{
		_construction = CreateConstruction(constructionType);
	}

	private GameObject CreateConstruction(ConstructionType constructionType)
	{
		GameObject prefab = _availableConstructions.GetPrefab(constructionType);
		return Instantiate(prefab, _parent);
	}
	
	public void StartConstruction()
	{
		_isPlayerTriggered = true;
		_constructionHammer.gameObject.SetActive(_isPlayerTriggered);
	}

	public void StopConstruction()
	{
		_isPlayerTriggered = false;
		_constructionHammer.gameObject.SetActive(_isPlayerTriggered);
	}
}