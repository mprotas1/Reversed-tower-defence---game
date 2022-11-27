using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerInstance : Tower
{
    private void Start()
    {
        this.InitializeTower();
    }

    public override void Attack(Minion minion)
    {
        minion.ReceiveDamage(this.AttackPoints);
    }

    public override void OnDead()
    {
        if(IsDestroyed())
        {
            // for now just displaying whether is dead
            Debug.Log("I'm dead!");
            // playing destroying of tower animation
            // TODO

            // destroying the whole object
            Destroy(this.gameObject);
        }
    }

    public override void ReceiveDamage(double damagePoints)
    {
        Debug.Log(HealthPoints);
        this.HealthPoints -= damagePoints;
    }
}
