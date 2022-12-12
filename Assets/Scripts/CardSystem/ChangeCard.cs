using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class ChangeCard : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private Card card;

    [SerializeField]
    private Card[] cards;

    [SerializeField]
    private GameObject DescriptionPrefab;

    private GameObject Description;

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

    public void OnPointerExit(PointerEventData eventData)
    {
        Destroy(Description);
        Description = null;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(Description is null)
        {
            Description = GameObject.Instantiate(DescriptionPrefab, 
                transform.position,
                Quaternion.identity);

            Description.transform.position = new Vector3(transform.position.x + 50, transform.position.y + 120);

            Description.transform.SetParent(transform, false);
        }
    }
}
