using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilContoller : MonoBehaviour
{
    public float soilQuality = 15;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("_Seed"))
        {
            other.SendMessage("SetSoilBonus", soilQuality);

            if(soilQuality > 0)
            {
                soilQuality -= 1;
            }
        }
    }

    public void AddSoilQuality()
    {
        if(soilQuality < 20)
        {
            soilQuality += 1;
        }
    }
}
