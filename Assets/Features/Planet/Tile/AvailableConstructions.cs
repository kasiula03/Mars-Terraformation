using System;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "AvailableConstructions", menuName = "Constructions/AvailableConstructions", order = 1)]
public class AvailableConstructions : ScriptableObject
{
	public GameObject Forest;
	public GameObject City;
	public GameObject Ocean;

	public GameObject GetPrefab(ConstructionType constructionType)
	{
		switch (constructionType)
		{
			case ConstructionType.FOREST:
				return Forest;
			case ConstructionType.CITY:
				return City;
			case ConstructionType.OCEAN:
				return Ocean;
			default:
				throw new ArgumentOutOfRangeException(nameof(constructionType), constructionType, null);
		}
	}
}