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
    public double Attack;
    public double Range;
    public int MoneyForDestroying;
}
