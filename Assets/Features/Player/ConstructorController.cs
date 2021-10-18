using System;
using UnityEngine;

public class ConstructorController : MonoBehaviour
{
    [SerializeField] private Transform _constructionPreviewParent;
    [SerializeField] private AvailableConstructions _availableConstructions;

    private ConstructionType _selectedConstruction = ConstructionType.NONE;

    private GameObject _selectedPreviewObject;
    private PlayerResources _playerResources;
    private TerraformationStats _terraformationStats;

    private readonly ObjectOnPlace<ConstructionPlace> _constructionPlace = new ObjectOnPlace<ConstructionPlace>(
        "ConstructionPlace", OnEnterConstructionPlace, OnExitConstructionPlace);

    private readonly ObjectOnPlace<ConstructorPlace> _constructorPlace =
        new ObjectOnPlace<ConstructorPlace>("ConstructorPlace");

    public void Start()
    {
        _playerResources = FindObjectOfType<PlayerResources>();
        _terraformationStats = FindObjectOfType<TerraformationStats>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_constructorPlace.IsOnPlace && CanConstruct(_constructorPlace.Object))
            {
                SelectToConstruct();
            }
            else if (_selectedConstruction != ConstructionType.NONE && _constructionPlace.IsOnPlace &&
                     _constructionPlace.Object.IsAbleToBuild(_selectedConstruction))
            {
                AdjustCurrency(_selectedConstruction);
                _constructionPlace.Object.Build(_selectedConstruction);
                Destroy(_selectedPreviewObject);
                _selectedConstruction = ConstructionType.NONE;
            }
        }
    }

    private bool CanConstruct(ConstructorPlace constructorPlace)
    {
        ConstructionType constructionType = constructorPlace.ConstructionType;
        return _playerResources.HasEnoughCurrency(constructionType);
    }

    private void AdjustCurrency(ConstructionType selectedConstruction)
    {
        _playerResources.DecreaseResourceByConstruction(selectedConstruction);

        if (selectedConstruction == ConstructionType.CITY)
        {
            _playerResources.AddResourceIncome(PlayerResources.Currency.GOLD, 1);
        }

        if (selectedConstruction == ConstructionType.FOREST)
        {
            _terraformationStats.AddOxygen(1);
        }

        if (selectedConstruction == ConstructionType.OCEAN)
        {
            _terraformationStats.AddOcean(1);
        }
    }

    private void SelectToConstruct()
    {
        _selectedConstruction = _constructorPlace.Object.ConstructionType;
        GameObject prefab = _availableConstructions.GetPrefab(_selectedConstruction);
        _selectedPreviewObject = Instantiate(prefab, _constructionPreviewParent);
    }

    private void OnTriggerEnter(Collider other)
    {
        _constructionPlace.CheckEnter(other);
        _constructorPlace.CheckEnter(other);
    }

    private void OnTriggerExit(Collider other)
    {
        _constructionPlace.CheckExit(other);
        _constructorPlace.CheckExit(other);
    }

    private static void OnEnterConstructionPlace(ConstructionPlace constructionPlace)
    {
        if (constructionPlace.IsEmpty)
        {
            constructionPlace.StartConstruction();
        }
    }

    private static void OnExitConstructionPlace(ConstructionPlace constructionPlace)
    {
        if (constructionPlace.IsEmpty)
        {
            constructionPlace.StopConstruction();
        }
    }
}