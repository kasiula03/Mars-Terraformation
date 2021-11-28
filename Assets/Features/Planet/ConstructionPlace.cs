using DG.Tweening;
using UnityEngine;

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
        StopConstruction();

        //TODO: Clean it up
        if (_oceanSpot)
        {
            GetComponentInChildren<MeshRenderer>().material.color = Color.blue;
        }
    }

    public bool IsAbleToBuild(ConstructionType constructionType)
    {
        return IsEmpty && ((constructionType == ConstructionType.OCEAN && _oceanSpot) ||
                           (constructionType != ConstructionType.OCEAN && !_oceanSpot));
    }

    public void Build(ConstructionType constructionType)
    {
        PlaceBuilding(constructionType);
        StopConstruction();
        _hammerSequence.Kill();
    }

    private void PlaceBuilding(ConstructionType constructionType)
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

        _hammerSequence?.Kill();
        _hammerSequence = DOTween.Sequence();
        _hammerSequence.Append(_constructionHammer.DORotateAroundAxis(_constructionHammer.up, 360, 2f));
        _hammerSequence.SetLoops(-1);
    }

    public void StopConstruction()
    {
        _hammerSequence?.Kill();
        _isPlayerTriggered = false;
        _constructionHammer.gameObject.SetActive(_isPlayerTriggered);
    }
}