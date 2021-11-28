using System;
using UnityEngine;
using UnityEngine.UI;

public class ComputerController : MonoBehaviour
{
    [SerializeField] private Button _leftArrow;
    [SerializeField] private Button _rightArrow;
    [SerializeField] private CardPresenter _leftCard;
    [SerializeField] private CardPresenter _centerCard;
    [SerializeField] private CardPresenter _rightCard;

    private Action _endAction;


    private int _currentCarouselIndex = 0;

    private ComputerPageInterface _computerPage;

    private void Start()
    {
        _leftArrow.onClick.AddListener(() => MoveCarousel(-1));
        _rightArrow.onClick.AddListener(() => MoveCarousel(1));
        SetupView(0);
    }

    public void Show(Action endAction, ComputerPageInterface pageInterface)
    {
        _endAction = endAction;
        _computerPage = pageInterface;
        gameObject.SetActive(true);
        SetupView(0);
    }

    public void Close()
    {
        gameObject.SetActive(false);
        _endAction?.Invoke();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveCarousel(-1);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveCarousel(1);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Close();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _computerPage.UseCard();
            Close();
        }
    }


    private void MoveCarousel(int offset)
    {
        int newCarouselSpot = _currentCarouselIndex + offset;
        if (_computerPage.Cards.Count > newCarouselSpot && newCarouselSpot >= 0)
        {
            _currentCarouselIndex = newCarouselSpot;
            SetupView(newCarouselSpot);
            _computerPage.MoveCarousel(_currentCarouselIndex);
        }
    }

    private void SetupView(int middleIndex)
    {
        _leftCard.gameObject.SetActive(middleIndex != 0);
        _rightCard.gameObject.SetActive(middleIndex < _computerPage.Cards.Count - 1);
        _centerCard.gameObject.SetActive(middleIndex < _computerPage.Cards.Count);

        bool isRightCardVisible = _currentCarouselIndex < _computerPage.Cards.Count - 1;
        bool isLeftCardVisible = _currentCarouselIndex > 0;

        if (isLeftCardVisible)
        {
            _leftCard.Setup(middleIndex - 1, _computerPage.GetCard(middleIndex - 1));
        }

        if (isRightCardVisible)
        {
            _rightCard.Setup(middleIndex + 1, _computerPage.GetCard(middleIndex + 1));
        }

        if (middleIndex < _computerPage.Cards.Count)
        {
            _centerCard.Setup(middleIndex, _computerPage.GetCard(middleIndex));
        }

        _rightArrow.gameObject.SetActive(isRightCardVisible);
        _leftArrow.gameObject.SetActive(isLeftCardVisible);
    }
}