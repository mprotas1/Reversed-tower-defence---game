using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UImanagement : MonoBehaviour
{
    [SerializeField]
    private float timeDelay = 2.0f;

    private MoneyManager moneyManager;
    private TextMeshProUGUI moneyText;
    private GameObject notEnoughMoneyText;

    private GameObject PauseMenu;

    private string popupText;

    public static bool IsPauseMenuOpened;

    void Start()
    {
        // getting reference to the needed objects
        moneyManager = GameObject.Find("GameManager").GetComponent<MoneyManager>();
        moneyText = GameObject.Find("MoneyText").GetComponent<TextMeshProUGUI>();
        notEnoughMoneyText = GameObject.Find("PopupText");

        PauseMenu = GameObject.Find("PauseMenu");
        PauseMenu.SetActive(false);

        popupText = notEnoughMoneyText.GetComponent<TextMeshProUGUI>().text;

        // for now, disabling the popup text
        notEnoughMoneyText.SetActive(false);

        moneyManager.OnMoneyChanged += UpdateMoneyText;
        Spawner.OnMinionFalsePlacing += ShowPopup;

        moneyText.SetText(moneyManager.GetCurrentMoney().ToString());

        IsPauseMenuOpened = false;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && IsPauseMenuOpened == false)
        {
            // stop the time
            Time.timeScale = 0.0f;

            // open the PauseMenu
            PauseMenu.SetActive(true);

            // reverse the flag
            IsPauseMenuOpened = !IsPauseMenuOpened;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && IsPauseMenuOpened == true)
        {
            // restart the time
            Time.timeScale = 1.0f;

            // close the PauseMenu
            PauseMenu.SetActive(false);

            // reverse the flag
            IsPauseMenuOpened = !IsPauseMenuOpened;
        }
    }

    private void UpdateMoneyText(int value)
    {
        moneyText.SetText(value.ToString());
    }

    private void ShowPopup(int deficitValue)
    {
        notEnoughMoneyText.GetComponent<TextMeshProUGUI>().SetText(
            popupText+
            " (need: " +
            deficitValue +
            ")");
        StopAllCoroutines();
        StartCoroutine(DelayTextDisapper());
    }

    private IEnumerator DelayTextDisapper()
    {
        notEnoughMoneyText.SetActive(true);
        yield return new WaitForSeconds(timeDelay);
        notEnoughMoneyText.SetActive(false);
    }
}
