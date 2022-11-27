using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tower data", menuName = "Data/Tower Data")]
public class TowerData : ScriptableObject
{
    [Header("Tower Parameters")]

    public string towerName;
    [Space(20)]
    [Range(0, 500)]
    public double HealthPoints;

    [Range(0, 100)]
    public double AttackPoints;

    [Range(0, 10)]
    public float Range;

    [Range(0, 250)]
    public int MoneyForDestroying;
}
