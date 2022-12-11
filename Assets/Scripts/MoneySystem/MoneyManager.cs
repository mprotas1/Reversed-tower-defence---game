using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MoneyManager : MonoBehaviour
{
    private readonly int InitialMoney = 200;

    private float timer = 0f;

    [SerializeField]
    private double delayAmount = 1;

    private int CurrentMoney { get; set; }

    private Spawner Spawner;

    public event Action<int> OnMoneyChanged;

    // Start is called before the first frame update
    void Awake()
    {
        // reference to the Spawner event when its spawning minion
        Spawner = GameObject.Find("MinionSpawner").GetComponent<Spawner>();
        Spawner.OnMinionPlaced += SubstractMoney;
        this.CurrentMoney = InitialMoney;
        SceneManager.activeSceneChanged += OnLevelChange;
    }

    private void Update()
    {
        AddCoins();
    }

    private void AddMoney(int value)
    {
        this.CurrentMoney += value;
    }

    private void SubstractMoney(int value)
    {
        this.CurrentMoney -= value;
        OnMoneyChanged(CurrentMoney);
    }

    private void OnLevelChange(Scene current, Scene next)
    {
        // if level is changed - reset money value of player
        if(next.ToString().Contains("Level"))
        {
            this.CurrentMoney = 0;
        }
    }

    public int GetCurrentMoney()
    {
        return this.CurrentMoney;
    }

    private void AddCoins()
    {
        timer += Time.deltaTime;

        if (timer >= delayAmount)
        {
            timer = 0f;
            AddMoney(1);
            OnMoneyChanged(CurrentMoney);
        }
    }
}
