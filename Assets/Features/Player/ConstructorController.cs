using UnityEngine;

public class ConstructorController : MonoBehaviour
{
	[SerializeField] private Transform _constructionPreviewParent;
	[SerializeField] private AvailableConstructions _availableConstructions;

	private ConstructionType _selectedConstruction = ConstructionType.NONE;
	private ConstructionPlace _currentConstructionPlace;
	private ConstructorPlace _currentConstructorPlace;

	private GameObject _selectedPreviewObject;
	private CityController _cityController;

	private void Update()
	{
		if (_selectedConstruction != ConstructionType.NONE && _currentConstructionPlace &&
		    _currentConstructionPlace.IsEmpty && Input.GetKeyDown(KeyCode.Space))
		{
			_currentConstructionPlace.Build(_selectedConstruction);
			Destroy(_selectedPreviewObject);
			_selectedConstruction = ConstructionType.NONE;
			//TODO: -currency
		}

		if (_currentConstructorPlace && Input.GetKeyDown(KeyCode.Space))
		{
			SelectToConstruct();
		}

		if (_cityController && _cityController.IsCoinToCollect && Input.GetKeyDown(KeyCode.Space))
		{
			_cityController.CollectCoin();
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

		if (other.CompareTag("City"))
		{
			_cityController = other.GetComponent<CityController>();
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

		if (other.CompareTag("City"))
		{
			_cityController = null;
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