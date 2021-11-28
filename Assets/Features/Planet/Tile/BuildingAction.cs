using System;
using UnityEngine;

public interface BuildingAction
{
	public bool IsBlocking();
	
	public bool IsActionAvailable();

	public void Execute(Action endAction);
}