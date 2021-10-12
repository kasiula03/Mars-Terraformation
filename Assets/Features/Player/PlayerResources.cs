using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerResources : MonoBehaviour
{
	public event Action OnResourcesChanged;
	
	[SerializeField] private DayNightCycle _dayNightCycle;

	public enum Currency
	{
		LEAVES,
		HEATS,
		ENERGY,
		STEEL,
		TITAN,
		GOLD
	}

	public Dictionary<Currency, int> Currencies = new Dictionary<Currency, int>()
	{
		{Currency.LEAVES, 0},
		{Currency.HEATS, 0},
		{Currency.ENERGY, 0},
		{Currency.STEEL, 0},
		{Currency.TITAN, 0},
		{Currency.GOLD, 12}
	};
	public Dictionary<Currency, int> CurrenciesIncome = new Dictionary<Currency, int>()
	{
		{Currency.LEAVES, 0},
		{Currency.HEATS, 0},
		{Currency.ENERGY, 0},
		{Currency.STEEL, 0},
		{Currency.TITAN, 0},
		{Currency.GOLD, 20}
	};

	private void Start()
	{
		_dayNightCycle.OnNewDay += AddResourcesByIncome;
	}

	public void AddResource(Currency currency, int value)
	{
		Currencies[currency] += value;
		OnResourcesChanged?.Invoke();
	}
	
	public void AddResourcesByIncome()
	{
		foreach (Currency currency in Currencies.Keys.ToList())
		{
			Currencies[currency] += CurrenciesIncome[currency];
		}
		OnResourcesChanged?.Invoke();
	}
}