using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UImanagement : MonoBehaviour
{
    private MoneyManager moneyManager;
    private TextMeshProUGUI moneyText;

    void Start()
    {
        moneyManager = GameObject.Find("GameManager").GetComponent<MoneyManager>();
        moneyText = GameObject.Find("MoneyText").GetComponent<TextMeshProUGUI>();

        moneyManager.OnMoneyChanged += UpdateMoneyText;

        moneyText.SetText(moneyManager.GetCurrentMoney().ToString());
    }

    private void UpdateMoneyText(int value)
    {
        moneyText.SetText(value.ToString());
    }

}
