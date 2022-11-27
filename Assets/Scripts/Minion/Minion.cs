using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Minion : MonoBehaviour
{
    /*
     * Here is the main abstraction of every minion in game.
     * It has its own HP, Attack, Armor and Range of attack. 
     * It can Attack(), ReceiveDamage() or do something on getting killed
    */

    public double HealthPoints { get; set; }
    public double MaxHealthPoints { get; set; }
    public double Armor { get; private set; }
    public double AttackPoints { get; set; }
    public double Range { get; set; }
    public double AttackFrequency { get; set; }

    public  MinionData data;
    public abstract void ReceiveDamage(double damagePoints);
    public abstract void Attack(Tower tower);
    public abstract void OnDead();

    // initializing all stats of minion
    public virtual void InitializeMinion()
    {
        this.HealthPoints = data.HealthPoints;
        this.Armor = data.Armor;
        this.AttackPoints = data.AttackPoints;
        this.Range = data.Range;
        this.MaxHealthPoints = HealthPoints;
        this.AttackFrequency = data.AttackFrequency;
    }

    // return "true" if minion is dead - its HP is lower or equal to zero
    public virtual bool IsDead()
    {
        return HealthPoints <= 0;
    }
}
