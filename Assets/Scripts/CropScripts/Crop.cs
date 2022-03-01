using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Crop : ScriptableObject
{
    [Header("Information")]
    public int cropNumber;
    public string cropName;
    public string cropDescription;

    [Header("Seed Attributes")]
    public float seedValue;
    public float seedBonusPointsMax;
    public float seedGrowthTime;
    
    [Header("Tower Attributes")]
    public float cropAttack;
    public float cropFiringRate;
    public float cropBaseFiringRate;
    public float cropRange;
}
