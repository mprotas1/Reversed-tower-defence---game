using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerInstance : Tower
{
    public override void Attack(Minion minion)
    {
        minion.ReceiveDamage(this.AttackPoints);
    }

    public override void OnDead()
    {
        // for now just displaying whether is dead
        Debug.Log("I'm dead!");
    }

    public override void ReceiveDamage(double damagePoints)
    {
        this.HealthPoints -= damagePoints;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
