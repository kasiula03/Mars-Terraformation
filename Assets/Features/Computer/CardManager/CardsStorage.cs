using System;
using System.Collections.Generic;


public enum CardType
{
    UNDEFINED,
    EVENT,
    PROJECTS,
    ACTION,
}


public class Card
{
    public CardType Type;
    public string ConfigId;
    public List<CardAction> Actions;
}

public class CardsStorage
{
    public List<Card> Cards = new List<Card>();

    public CardsStorage()
    {
    }


    public Card GetCard(int index)
    {
        if (index < 0 || index > Cards.Count - 1)
        {
            return null;
        }

        return Cards[index];
    }

    public void RemoveCard(int index)
    {
        Cards.RemoveAt(index);
    }
}