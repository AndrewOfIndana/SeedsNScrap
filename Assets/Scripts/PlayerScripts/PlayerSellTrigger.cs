using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSellTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("_Crop"))
        {
            other.SendMessage("HitCrop");
        }
    }
}
