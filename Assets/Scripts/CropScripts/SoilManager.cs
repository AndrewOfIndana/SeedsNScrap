using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilManager : MonoBehaviour
{
    public SoilContoller[] soilPatches;

    void Awake()
    {
        InvokeRepeating("SoilPatchesUpdate", 60, 60);
    }

    void SoilPatchesUpdate()
    {
        for(int i = 0; i < soilPatches.Length; i++)
        {
            soilPatches[i].AddSoilQuality();
        }
    }
}
