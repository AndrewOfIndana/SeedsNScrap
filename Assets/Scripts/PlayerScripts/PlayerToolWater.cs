using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerToolWater : MonoBehaviour
{
    float water = 0;
    public float waterCapacity = 1000;
    public GameObject waterCollider;
    public Image waterCapacityUI;

    void Awake()
    {        
        waterCollider.SetActive(false);
    }

    void Update()
    {   
        if (waterCapacity > 0)
        {
            if(Input.GetButton("Fire1"))
            {
                water += 1;
                waterCapacityUI.fillAmount = 1 - (water / waterCapacity);
                waterCollider.SetActive(true);
            }
            else
            {
                waterCollider.SetActive(false);
            }
        }
        else if (waterCapacity <= 0)
        {
            waterCollider.SetActive(false);
        }
    }

    void Refill()
    {
        if (water >= 0)
        {
            water -= 1;
            waterCapacityUI.fillAmount = 1 - (water / waterCapacity);
        }
    }
}
