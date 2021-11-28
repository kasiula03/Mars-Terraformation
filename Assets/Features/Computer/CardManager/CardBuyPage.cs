using System.Collections.Generic;

public class CardBuyPage : ComputerPageInterface
{
    private int _currentCarouselIndex = 0;

    private CardsStorage _cardsStorage => _allCardStorages.ToBuyCards;
    private readonly AllCardStorages _allCardStorages;
    private readonly PlayerResources _playerResources;

    public CardBuyPage(PlayerResources playerResources, AllCardStorages storage)
    {
        _playerResources = playerResources;
        _allCardStorages = storage;
    }

    public List<Card> Cards => _cardsStorage.Cards;

    public void UseCard()
    {
        Card card = _cardsStorage.GetCard(_currentCarouselIndex);
        //TODO: Move to bought storage
    }

    public Card GetCard(int index)
    {
        return _cardsStorage.GetCard(index);
    }

    public void MoveCarousel(int currentCarouselIndex)
    {
        _currentCarouselIndex = currentCarouselIndex;
    }
}