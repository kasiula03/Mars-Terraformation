using System;
using UnityEngine;

public class CityController : MonoBehaviour, BuildingAction
{
	[SerializeField] private Transform _coin;

	private PlayerResources _playerResources;

	private int _coinToCollect = 1;

	private void Start()
	{
		_playerResources = FindObjectOfType<PlayerResources>();
		WaveTween.Tween(_coin);
	}

	//TODO: Is player in the city?
	private void Update()
	{
		_coin.gameObject.SetActive(IsActionAvailable());
	}

	public bool IsBlocking()
	{
		return false;
	}

	public bool IsActionAvailable()
	{
		return _coinToCollect > 0;
	}

	public void Execute(Action endAction)
	{
		_playerResources.AddResource(PlayerResources.Currency.GOLD, _coinToCollect);
		_coinToCollect = 0;
	}
}