using UnityEngine;

public class ForestCreatorController : MonoBehaviour
{
	[SerializeField] private ObjectNumber _leafAmount;
	[SerializeField] private ObjectNumber _leafIncome;

	private PlayerResources _playerResources;

	private void Start()
	{
		_playerResources = FindObjectOfType<PlayerResources>();

		_playerResources.OnResourcesChanged += UpdateNumbers;
		UpdateNumbers();
	}

	private void UpdateNumbers()
	{
		int leafAmount = _playerResources.Currencies[PlayerResources.Currency.LEAVES];
		_leafAmount.Create(leafAmount, Color.green);
		int leafIncome = _playerResources.CurrenciesIncome[PlayerResources.Currency.LEAVES];
		_leafIncome.Create(leafIncome, Color.green, true);
	}
}