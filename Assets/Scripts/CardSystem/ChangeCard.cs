using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ChangeCard : MonoBehaviour
{
    [SerializeField]
    private Card card;

    [SerializeField]
    private Card[] cards;

    public static event Action<Card> OnCardChange;

    private void Start()
    {
        int number = UnityEngine.Random.Range(0, cards.Length);
        SetCard(cards[number]);
        ChangeCardImage();
    }

    public void ChangeCardImage()
    {
        GetComponent<Image>().sprite = card.CardSprite;
    }

    public void ChangeOnClick()
    {
        int num = UnityEngine.Random.Range(0, cards.Length);
        OnCardChange(card);
        SetCard(cards[num]);
        ChangeCardImage();
    }

    public void SetCard(Card card)
    {
        this.card = card;
    }

    public Card GetCard()
    {
        return this.card;
    }
}
