using System;
using System.Collections.Generic;
using UnityEngine;

public class CardUsePage : ComputerPageInterface
{
    public List<Card> Cards => _cardsStorage.Cards;


    private CardsStorage _cardsStorage => _allCardStorages.BoughtCards;
    private readonly PlayerResources _playerResources;
    private readonly AllCardStorages _allCardStorages;
    private int _currentCarouselIndex = 0;

    public CardUsePage(PlayerResources playerResources, AllCardStorages storage)
    {
        _playerResources = playerResources;
        _allCardStorages = storage;
    }


    public Card GetCard(int index)
    {
        return _cardsStorage.GetCard(index);
    }

    public void MoveCarousel(int currentCarouselIndex)
    {
        _currentCarouselIndex = currentCarouselIndex;
    }

    public void UseCard()
    {
        Card card = _cardsStorage.GetCard(_currentCarouselIndex);
        foreach (CardAction cardAction in card.Actions)
        {
            if (cardAction is CardIncomeAction cardIncomeAction)
            {
                _playerResources.AddResourceIncome(cardIncomeAction.Currency, cardIncomeAction.Amount);
            }
            else if (cardAction is CardResourceAction cardResourceAction)
            {
                _playerResources.AddResource(cardResourceAction.Currency, cardResourceAction.Amount);
            }
        }

        _cardsStorage.RemoveCard(_currentCarouselIndex);
    }
}