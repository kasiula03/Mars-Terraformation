using UnityEngine;

[CreateAssetMenu(fileName = "Numbers", menuName = "Constructions/Numbers", order = 1)]
public class NumberPrefabs : ScriptableObject
{
	[SerializeField] private GameObject _one;
	[SerializeField] private GameObject _two;
	[SerializeField] private GameObject _three;
	[SerializeField] private GameObject _four;
	[SerializeField] private GameObject _five;
	[SerializeField] private GameObject _six;
	[SerializeField] private GameObject _seven;
	[SerializeField] private GameObject _eight;
	[SerializeField] private GameObject _nine;
	[SerializeField] private GameObject _zero;

	public GameObject GetPrefab(int number)
	{
		switch (number)
		{
			case 1:
				return _one;
			case 2:
				return _two;
			case 3:
				return _three;
			case 4:
				return _four;
			case 5:
				return _five;
			case 6:
				return _six;
			case 7:
				return _seven;
			case 8:
				return _eight;
			case 9:
				return _nine;
			case 0:
				return _zero;
			default:
				return null;
		}
	} 
	
}