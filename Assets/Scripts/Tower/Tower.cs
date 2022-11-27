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

    public double HealthPoints;
    public double MaxHealthPoints;
    public double AttackPoints;
    public double Range;
    public int MoneyForDestroying;
    public TowerData data;
    public abstract void ReceiveDamage(double damagePoints);
    public abstract void Attack(Minion minion);
    public abstract void OnDead();

    public virtual void InitializeTower()
    {
        this.HealthPoints = data.HealthPoints;
        this.AttackPoints = data.AttackPoints;
        this.Range = data.Range;
        this.MaxHealthPoints = HealthPoints;
    }

    // return "true" if tower is destroyed - its HP is lower or equal to zero
    public bool IsDestroyed()
    {
        return HealthPoints <= 0;
    }
}
