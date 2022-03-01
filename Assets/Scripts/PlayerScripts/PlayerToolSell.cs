using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerToolSell : MonoBehaviour
{
    public GameObject digCollider;
    public float digTime = 0;
    public float digTimeMax = 5;
    public Image digTimeDial;

    void Awake()
    {        
        digCollider.SetActive(false);
    }

    void FixedUpdate()
    {        
        if(Input.GetMouseButton(0))
        {
            digTime += Time.deltaTime;
            digTimeDial.fillAmount = (digTime / digTimeMax);

            if(digTime >= digTimeMax)
            {
                digTime = 0;
                digCollider.SetActive(true);
                Invoke("DigReset", .5f);
            }
        }
        else
        {
            digCollider.SetActive(false);
            digTime = 0;
            digTimeDial.fillAmount = (digTime / digTimeMax);
        }
    }
    void DigReset()
    {
        digCollider.SetActive(false);
    }
}
