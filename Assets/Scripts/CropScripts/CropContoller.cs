using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropContoller : MonoBehaviour
{
    //change for testing
    private Crop cropStats;
    
    public GameObject seed;
    public GameObject tower;
    public float produce;
    private float seedBonus;

    public void SetCropStats(Crop _itemCropID)
    {
        cropStats = _itemCropID;
        ItemToSeed();
    }

    void ItemToSeed()
    {
        seed.SetActive(true);
        CropSeedController seedScript = seed.GetComponent<CropSeedController>();
        seedScript.AwakeSeed(cropStats);
    }

    public void SeedToCrop(float sdBonus)
    {
        seedBonus = sdBonus;
        produce = Mathf.Round(cropStats.seedValue * seedBonus);
        seed.SetActive(false);
        CropTowerController towerScript = tower.GetComponent<CropTowerController>();
        towerScript.AwakeTower(seedBonus, cropStats);
    }


    public void SellCrop()
    {
        GameManager gManager = GameObject.FindGameObjectWithTag("_GameManager").GetComponent<GameManager>();
        gManager.SendMessage("AddMoney", produce);
        Destroy(gameObject);
    }
}
