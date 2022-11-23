using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Minion data", menuName = "Data/Minion Data")]
public class MinionData : ScriptableObject
{
    [Header("Minion Parameters")]

    public string minionName;
    [Space(20)]
    [Range(0, 100)]
    public double HealthPoints;

    [Range(0, 50)]
    public double Armor;

    [Range(0, 100)]
    public double AttackPoints;

    [Range(0, 10)]
    public float Range;
}
