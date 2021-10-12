using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlanetGrid : MonoBehaviour
{
	[SerializeField] private Transform _planet;
	public GameObject GridPrefab;
	public int GridsAmount = 0;

	private Vector3 _startPoint = Vector3.zero;

	public void Start()
	{
		float radius = transform.lossyScale.x / 2;
		float surfaceArea = 4 * Mathf.PI * Mathf.Pow(radius, 2);
		float areaPerGrid = surfaceArea / GridsAmount;
		Vector3 center = _planet.position;
		Vector3 startingPoint = GridPosition(center, radius, 0, 0);
		Vector3 offset = Vector3.zero;

		// CreateTile(center, startingPoint);
		// startingPoint = GridPosition(center, radius, 30, 0) + offset;
		// CreateTile(center, startingPoint);
		// offset = new Vector3(0f, 1.8f, 1.5f);
		// startingPoint = GridPosition(center, radius, 0, 9) + offset;
		// CreateTile(center, startingPoint);

		// for (int i = 0; i < GridsAmount; i++)
		// {
		// 	//Vector3 pos = startingPoint;
		// 	float angle = 360 * ((float) i / GridsAmount);
		// 	Vector3 pos = GridPosition(center , radius , angle + 30, 90);
		// 	CreateTile(center, pos);
		// 	// pos = GridPosition(center, radius, 0, angle);
		// 	// GameObject obj = CreateTile(center, pos);
		// 	// Quaternion newRotation = obj.transform.rotation;
		//
		// 	//	obj.transform.Rotate( _planet.up, 20);
		// 	//startingPoint += _planet.right;
		// }
		//	CreateGrid(areaPerGrid);
	}

	private GameObject CreateTile(Vector3 center, Vector3 pos)
	{
		Quaternion rot = Quaternion.FromToRotation(_planet.up, center - pos);
		GameObject obj = Instantiate(GridPrefab, pos, rot);
		obj.transform.SetParent(_planet, true);
		obj.transform.localScale = Vector3.one;
		return obj;
	}

	Vector3 GridPosition(Vector3 center, float radius, float angle, float polarAngle)
	{
		Vector3 pos;

		float elevation = angle * Mathf.Deg2Rad;
		float polar = polarAngle * Mathf.Deg2Rad;

		float a = radius * Mathf.Cos(elevation);
		pos.x = center.x + a * Mathf.Cos(polar);
		pos.y = center.y + radius * Mathf.Sin(elevation);
		pos.z = center.z + a * Mathf.Sin(polar);

		//pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
		//pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
		//pos.z = center.z + 5f;
		return pos;
	}

	private void CreateGrid(float areaPerGrid)
	{
		for (int i = 0; i < GridsAmount; i++)
		{
		}
	}
}