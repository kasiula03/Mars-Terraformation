using UnityEngine;

public interface BuildingAction
{
	public bool IsActionAvailable();

	public void Execute();
}