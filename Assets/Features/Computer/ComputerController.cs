using UnityEngine;
using UnityEngine.UI;

public class ComputerController : MonoBehaviour
{
    [SerializeField] private Button _leftArrow;
    [SerializeField] private Button _rightArrow;
    [SerializeField] private CardPresenter _leftCard;
    [SerializeField] private CardPresenter _centerCard;
    [SerializeField] private CardPresenter _rightCard;

    private CardsStorage _cardsStorage = new CardsStorage();
    private int _currentCarouselIndex = 0;

    private void Start()
    {
        _leftArrow.onClick.AddListener(() => MoveCarousel(-1));
        _rightArrow.onClick.AddListener(() => MoveCarousel(1));
        SetupView(0);
    }

    private void MoveCarousel(int offset)
    {
        int newCarouselSpot = _currentCarouselIndex + offset;
        if (_cardsStorage.Cards.Count > newCarouselSpot && newCarouselSpot >= 0)
        {
            _currentCarouselIndex = newCarouselSpot;
            SetupView(newCarouselSpot);
        }
    }

    private void SetupView(int middleIndex)
    {
        _leftCard.gameObject.SetActive(middleIndex != 0);
        _rightCard.gameObject.SetActive(middleIndex != _cardsStorage.Cards.Count - 1);

        bool isRightCardVisible = _currentCarouselIndex < _cardsStorage.Cards.Count - 1;
        bool isLeftCardVisible = _currentCarouselIndex > 0;

        if (isLeftCardVisible)
        {
            _leftCard.Setup(middleIndex - 1, _cardsStorage.GetCard(middleIndex - 1));
        }

        if (isRightCardVisible)
        {
            _rightCard.Setup(middleIndex + 1, _cardsStorage.GetCard(middleIndex + 1));
        }

        _centerCard.Setup(middleIndex, _cardsStorage.GetCard(middleIndex));

        _rightArrow.gameObject.SetActive(isRightCardVisible);
        _leftArrow.gameObject.SetActive(isLeftCardVisible);
    }
}