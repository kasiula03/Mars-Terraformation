using System;
using System.Collections.Generic;

public interface ComputerPageInterface
{
    public List<Card> Cards { get; }

    public void UseCard();

    public Card GetCard(int index);
    public void MoveCarousel(int currentCarouselIndex);
}