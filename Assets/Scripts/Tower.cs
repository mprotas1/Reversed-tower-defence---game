using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;

public abstract class Tower : MonoBehaviour
{
    public double HealthPoints;
    public double MaxHealthPoints;
    public double Attack;
    public double Range;
    public int MoneyForDestroying;
}
