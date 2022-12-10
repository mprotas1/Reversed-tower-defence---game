using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MoneyManager : MonoBehaviour
{
    private readonly int InitialMoney = 200;
    private int CurrentMoney { get; set; }

    private Spawner Spawner;

    public event Action<int> OnMoneySubstracted;

    // Start is called before the first frame update
    void Awake()
    {
        // reference to the Spawner event when its spawning minion
        Spawner = GameObject.Find("MinionSpawner").GetComponent<Spawner>();
        Spawner.OnMinionPlaced += SubstractMoney;
        this.CurrentMoney = InitialMoney;
        SceneManager.activeSceneChanged += OnLevelChange;
    }

    private void AddMoney(int value)
    {
        this.CurrentMoney += value;
    }

    private void SubstractMoney(int value)
    {
        this.CurrentMoney -= value;
        OnMoneySubstracted(CurrentMoney);
    }

    void OnLevelChange(Scene current, Scene next)
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
}
