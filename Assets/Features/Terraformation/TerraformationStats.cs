using UnityEngine;

public class TerraformationStats : MonoBehaviour
{
	public int CurrentOceans = 0;
	public int CurrentOxygenPercent = 0;
	public int CurrentTemp = -30;

	private int _requiredOceans = 0;
	private int _requiredOxygen = 12;
	private int _requiredTemp = 8;

	public bool IsTerraformed => CurrentOceans == _requiredOceans && CurrentOxygenPercent == _requiredOxygen &&
	                             CurrentTemp == _requiredTemp;

	public void AddTemp(int temp)
	{
		CurrentTemp += temp;
	}

	public void AddOxygen(int oxygen)
	{
		CurrentOxygenPercent += oxygen;
	}

	public void AddOcean(int ocean)
	{
		CurrentOceans += ocean;
	}
}