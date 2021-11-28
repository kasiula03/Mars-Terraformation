using System;
using UnityEngine;

public class ComputerOpenAction : MonoBehaviour, BuildingAction
{
    [SerializeField] private ComputerController _computerPanel;
    [SerializeField] private CardManager _cardManager;

    private CardUsePage _cardUsePage;
    private CardBuyPage _cardBuyPage;

    private void Awake()
    {
        PlayerResources playerResources = FindObjectOfType<PlayerResources>();
        _cardUsePage = new CardUsePage(playerResources, _cardManager.AllCardStorages);
        _cardBuyPage = new CardBuyPage(playerResources, _cardManager.AllCardStorages);
    }

    public bool IsBlocking()
    {
        return true;
    }

    public bool IsActionAvailable()
    {
        return true;
    }

    public void Execute(Action endAction)
    {
        _computerPanel.Show(endAction, _cardBuyPage);
    }
}