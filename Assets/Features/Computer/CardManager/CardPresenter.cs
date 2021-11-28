using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardPresenter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _number;
    [SerializeField] private Image _background;

    public void Setup(int number, Card card)
    {
        _number.text = number.ToString();
        switch (card.Type)
        {
            case CardType.UNDEFINED:
                break;
            case CardType.EVENT:
                _background.color = Color.red;
                break;
            case CardType.PROJECTS:
                _background.color = Color.cyan;
                break;
            case CardType.ACTION:
                _background.color = Color.green;
                break;
            
        }
    }
}
