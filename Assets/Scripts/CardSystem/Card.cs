using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card data", menuName = "Data/Card")]
public class Card : ScriptableObject
{
    [Header("Create a card")]

    public Sprite CardSprite;
    public GameObject CardPrefab;
    public int CashForMinion;

    public override string ToString()
    {
        MinionData cardDesc = CardPrefab.GetComponent<Minion>().data;
        return "Card with name: " + this.name + "\nCost: " + CashForMinion + cardDesc.ToString();
    }
}
