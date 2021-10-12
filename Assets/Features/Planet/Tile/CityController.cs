using UnityEngine;

public class CityController : MonoBehaviour
{
	[SerializeField] private Transform _coin;

	private PlayerResources _playerResources;
	public bool IsCoinToCollect => _coinToCollect > 0;
	private int _coinToCollect = 1;
	
	private void Start()
	{
		_playerResources = FindObjectOfType<PlayerResources>();
		WaveTween.Tween(_coin);
	}

	//TODO: Is player in the city?
	private void Update()
	{
		_coin.gameObject.SetActive(IsCoinToCollect);
	}

	public void CollectCoin()
	{
		_playerResources.AddResource(PlayerResources.Currency.GOLD, _coinToCollect);
		_coinToCollect = 0;
	}
}
