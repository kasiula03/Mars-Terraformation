using UnityEngine;

public class FactoryController : MonoBehaviour
{
    [SerializeField] private ObjectNumber _heatAmount;
    [SerializeField] private ObjectNumber _heatIncome;

    private PlayerResources _playerResources;

    private void Start()
    {
        _playerResources = FindObjectOfType<PlayerResources>();

        _playerResources.OnResourcesChanged += UpdateNumbers;
        UpdateNumbers();
    }

    private void UpdateNumbers()
    {
        int heatAmount = _playerResources.Currencies[PlayerResources.Currency.HEATS];
        _heatAmount.Create(heatAmount, new Color(0.8313726F, 0.6862745F, 0.2156863F, 1f));
        int heatIncome = _playerResources.CurrenciesIncome[PlayerResources.Currency.HEATS];
        _heatIncome.Create(heatIncome, new Color(0.8313726F, 0.6862745F, 0.2156863F, 1f), true);
    }
}