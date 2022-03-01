using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropSeedController : MonoBehaviour
{
    [Header("Numerators")]
    public float waterIntake = 0;
    public int soilIntake = 0;

    //Header("Denominator")//
    private Crop seedMaxes;
    public float waterIntakeMax;

    [Header("Variables")]
    private float countdownSeed = 0f;
    public float cropBonus;

    public void AwakeSeed(Crop _seedStat)
    {
        seedMaxes = _seedStat;
        countdownSeed = seedMaxes.seedGrowthTime;
        waterIntakeMax = seedMaxes.seedGrowthTime * 42;
        Invoke("Bonus", countdownSeed);
    }

    void Watering()
    {
        waterIntake += 1;
    }

    void SetSoilBonus(int _soilQuality)
    {
        soilIntake = _soilQuality;
    }

    public void Bonus()
    {
        float waterOuttake = (waterIntake/waterIntakeMax) + 1;
        int soilOuttake = (soilIntake/10) + 1;
        float seedBonusPoints = waterOuttake * soilOuttake * (float)1.773 * seedMaxes.seedValue;
        float seedBonusCalc = (seedBonusPoints/seedMaxes.seedBonusPointsMax)*100;

        if (seedBonusCalc <= 30)
        {
            cropBonus = 1; //C
        }
        else if (seedBonusCalc >= 31 && seedBonusCalc <= 60)
        {
            cropBonus = (float)1.25; //B
        }
        else if (seedBonusCalc >= 61 && seedBonusCalc <= 80)
        {
            cropBonus = (float)1.5; //A
        }
        else if (seedBonusCalc >= 81 && seedBonusCalc <= 100)
        {
            cropBonus = (float)1.75; //S
        }
        else if (seedBonusCalc >= 101)
        {
            cropBonus = 2; //S+
        }
        else
        {
            cropBonus = (float)1.25;
        }

        gameObject.SendMessageUpwards("SeedToCrop", cropBonus);
    }
}
