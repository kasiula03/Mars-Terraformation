using UnityEngine;

public class BankController : MonoBehaviour
{
	[SerializeField] private ObjectNumber _goldAmount;
	[SerializeField] private ObjectNumber _goldIncome;

	[SerializeField] private PlayerResources _playerResources;

	private void Start()
	{
		_playerResources.OnResourcesChanged += UpdateNumbers;
		UpdateNumbers();
	}

	private void UpdateNumbers()
	{
		int goldAmount = _playerResources.Currencies[PlayerResources.Currency.GOLD];
		_goldAmount.Create(goldAmount, new Color(0.8313726F, 0.6862745F, 0.2156863F, 1f));
		int goldIncome = _playerResources.CurrenciesIncome[PlayerResources.Currency.GOLD];
		_goldIncome.Create(goldIncome, new Color(0.8313726F, 0.6862745F, 0.2156863F, 1f));
	}
}