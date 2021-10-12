using UnityEngine;

public class LookAtPoint : MonoBehaviour
{
	public Transform Planet;
	public Vector3 lookAtPoint = Vector3.zero;

	public void Rotate()
	{
		transform.rotation = Quaternion.FromToRotation(-Planet.up, lookAtPoint - transform.position);
	}
}