using System;
using UnityEngine;

public class ConstructorController : MonoBehaviour
{
	[SerializeField] private Transform _constructionPreviewParent;
	[SerializeField] private AvailableConstructions _availableConstructions;

	private ConstructionType _selectedConstruction = ConstructionType.NONE;
	private ConstructionPlace _currentConstructionPlace;
	private ConstructorPlace _currentConstructorPlace;

	private GameObject _selectedPreviewObject;
	private PlayerResources _playerResources;
	private TerraformationStats _terraformationStats;
	private BuildingAction _buildingAction;

	public void Start()
	{
		_playerResources = FindObjectOfType<PlayerResources>();
		_terraformationStats = FindObjectOfType<TerraformationStats>();
	}

	private void Update()
	{
		if (_selectedConstruction != ConstructionType.NONE && _currentConstructionPlace &&
		    _currentConstructionPlace.IsEmpty && Input.GetKeyDown(KeyCode.Space))
		{
			AdjustCurrency(_selectedConstruction);
			_currentConstructionPlace.Build(_selectedConstruction);
			Destroy(_selectedPreviewObject);
			_selectedConstruction = ConstructionType.NONE;
			//TODO: -currency
		}

		if (_currentConstructorPlace && Input.GetKeyDown(KeyCode.Space) && CanConstruct(_currentConstructorPlace))
		{
			SelectToConstruct();
		}

		//TODO: Another controller
		if (_buildingAction != null && _buildingAction.IsActionAvailable() && Input.GetKeyDown(KeyCode.Space))
		{
			_buildingAction.Execute();
		}
	}

	private bool CanConstruct(ConstructorPlace constructorPlace)
	{
		ConstructionType constructionType = constructorPlace.ConstructionType;
		return _playerResources.HasEnoughCurrency(constructionType);
	}

	private void AdjustCurrency(ConstructionType selectedConstruction)
	{
		if (selectedConstruction == ConstructionType.CITY)
		{
			_playerResources.AddResource(PlayerResources.Currency.GOLD, -20);
			_playerResources.AddResourceIncome(PlayerResources.Currency.GOLD, 1);
		}

		if (selectedConstruction == ConstructionType.FOREST)
		{
			_playerResources.AddResource(PlayerResources.Currency.LEAVES, -8);
			_terraformationStats.AddOxygen(1);
		}
	}

	private void SelectToConstruct()
	{
		_selectedConstruction = _currentConstructorPlace.ConstructionType;
		GameObject prefab = _availableConstructions.GetPrefab(_selectedConstruction);
		_selectedPreviewObject = Instantiate(prefab, _constructionPreviewParent);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("ConstructionPlace"))
		{
			if (_currentConstructionPlace != null)
			{
				ClearConstructionSelection();
			}

			_currentConstructionPlace = other.GetComponent<ConstructionPlace>();
			if (_currentConstructionPlace.IsEmpty)
			{
				_currentConstructionPlace.StartConstruction();
			}
		}

		if (other.CompareTag("ConstructorPlace"))
		{
			_currentConstructorPlace = other.GetComponent<ConstructorPlace>();
		}

		if (other.CompareTag("BuildingAction"))
		{
			_buildingAction = other.GetComponent<BuildingAction>();
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("ConstructionPlace") && _currentConstructionPlace != null &&
		    other.gameObject == _currentConstructionPlace.gameObject)
		{
			ClearConstructionSelection();
		}

		if (other.CompareTag("ConstructorPlace"))
		{
			_currentConstructorPlace = null;
		}

		if (other.CompareTag("BuildingAction"))
		{
			_buildingAction = null;
		}
	}

	private void ClearConstructionSelection()
	{
		if (_currentConstructionPlace.IsEmpty)
		{
			_currentConstructionPlace.StopConstruction();
			_currentConstructionPlace = null;
		}
	}
}