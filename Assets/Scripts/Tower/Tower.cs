using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;

public abstract class Tower : MonoBehaviour
{
    /*
     * Here is the main abstraction of every tower in game.
     * It has its own HP, Attack and Range of attack. When player destroys it - he get MoneyForDestroying
    */

    public double HealthPoints { get; set; }
    public double MaxHealthPoints { get; set; }
    public double AttackPoints { get; set; }
    public double Range { get; set; }
    public int MoneyForDestroying { get; set; }
    public double AttackFrequency { get; set; }
    public TowerData data;
    public abstract void ReceiveDamage(double damagePoints);
    public abstract void Attack(Minion minion);
    public abstract void OnDead();

    public virtual void InitializeTower()
    {
        this.HealthPoints = data.HealthPoints;
        this.AttackPoints = data.AttackPoints;
        this.Range = data.Range;
        this.AttackFrequency = data.AttackFrequency;
        this.MaxHealthPoints = HealthPoints;
    }

    // return "true" if tower is destroyed - its HP is lower or equal to zero
    public bool IsDestroyed()
    {
        return HealthPoints <= 0;
    }
}
