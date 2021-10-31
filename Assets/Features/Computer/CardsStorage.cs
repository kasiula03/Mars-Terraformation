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
}

public class CardsStorage
{
    public List<Card> Cards = new List<Card>()
    {
        new Card() {Type = CardType.EVENT}, new Card() {Type = CardType.PROJECTS}, new Card() {Type = CardType.EVENT},
        new Card() {Type = CardType.ACTION}, new Card() {Type = CardType.PROJECTS}
    };

    public Card GetCard(int index)
    {
        if (index < 0 || index > Cards.Count - 1)
        {
            return null;
        }

        return Cards[index];
    }
}