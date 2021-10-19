using UnityEngine;

public class BoostUpTempAction : MonoBehaviour, BuildingAction
{
    private TerraformationStats _terraformationStats;
    private PlayerResources _playerResources;

    private void Start()
    {
        _terraformationStats = FindObjectOfType<TerraformationStats>();
        _playerResources = FindObjectOfType<PlayerResources>();
    }

    public bool IsActionAvailable()
    {
        return _playerResources.Currencies[PlayerResources.Currency.HEATS] >= 8;
    }

    public void Execute()
    {
        _terraformationStats.AddTemp(2);
        _playerResources.AddResource(PlayerResources.Currency.HEATS, -8);
    }
}