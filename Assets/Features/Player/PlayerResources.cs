using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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

	public static readonly Dictionary<ConstructionType, (Currency, int)> ConstructionCosts = new Dictionary<ConstructionType, (Currency, int)>
	{
		{ConstructionType.CITY, (Currency.GOLD, 20)},
		{ConstructionType.FOREST, (Currency.LEAVES, 8)},
		{ConstructionType.OCEAN, (Currency.GOLD, 35)}
	};

	public Dictionary<Currency, int> Currencies = new Dictionary<Currency, int>()
	{
		{Currency.LEAVES, 8},
		{Currency.HEATS, 199},
		{Currency.ENERGY, 0},
		{Currency.STEEL, 0},
		{Currency.TITAN, 0},
		{Currency.GOLD, 61}
	};
	public Dictionary<Currency, int> CurrenciesIncome = new Dictionary<Currency, int>()
	{
		{Currency.LEAVES, 0},
		{Currency.HEATS, 1},
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

	public void AddResourceIncome(Currency currency, int increaseIncome)
	{
		CurrenciesIncome[currency] += increaseIncome;
		OnResourcesChanged?.Invoke();
	}

	public void DecreaseResourceByConstruction(ConstructionType constructionType)
	{
		(Currency, int) cost = ConstructionCosts[constructionType];
		Currencies[cost.Item1] -= cost.Item2;
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

	public bool HasEnoughCurrency(ConstructionType constructionType)
	{
		(Currency, int) cost = ConstructionCosts[constructionType];
		return Currencies[cost.Item1] >= cost.Item2;
	}
}