using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionInstance : Minion
{
    public override void Attack(Tower tower)
    {
        tower.ReceiveDamage(this.AttackPoints);
    }

    public override void OnDead()
    {
        Debug.Log(gameObject.name + ": I'm dead!");
    }

    public override void ReceiveDamage(double damagePoints)
    {
        this.HealthPoints -= damagePoints;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.InitializeMinion();
        Debug.Log(this.ToString());
        Debug.Log(this.IsDead());
    }

    public override string ToString()
    {
        return "MaxHealthPoints: " + this.HealthPoints.ToString() +
            "\nArmor: " + this.Armor.ToString() +
            "\nRange: " + this.Range.ToString() +
            "\nAttack: " + this.AttackPoints.ToString();
    }
}
