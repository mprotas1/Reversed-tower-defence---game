using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // class designed to spawn our minions on the line
    [SerializeField]
    private GameObject minion;
    private readonly int radius = 5;
    [SerializeField]
    private Card card;

    private MoneyManager cashManager;

    public static event Action<int> OnMinionPlaced;

    private void Awake()
    {
        cashManager = GameObject.Find("GameManager").GetComponent<MoneyManager>();
        ChangeCard.OnCardChange += SpawnMinion;
    }

    private void SpawnMinion(Card card)
    {
        Debug.Log(cashManager);
        if(cashManager.GetCurrentMoney() >= card.CashForMinion)
        {
            Vector3 position = new Vector3(transform.position.x + UnityEngine.Random.Range(0, radius),
                transform.position.y,
                transform.position.z + UnityEngine.Random.Range(0, radius));
            GameObject.Instantiate(card.CardPrefab, position, Quaternion.identity);

            // brief other components that minion has been placed
            OnMinionPlaced(card.CashForMinion);
        }
        else
        {
            Debug.Log("You don't have enough money");
            // show message dialog that player does not have enough money
        }
        
    }


}

