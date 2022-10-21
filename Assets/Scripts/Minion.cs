using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Minion : MonoBehaviour
{
    /*
     * Here is the main abstraction of every minion in game.
     * It has its own HP, Attack and Range of attack. 
    */

    public double HealthPoints;
    public double MaxHealthPoints;
    public double Attack;
    public double Range;
}
