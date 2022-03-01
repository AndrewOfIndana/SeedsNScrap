using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWaterTrigger : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("_Seed"))
        {
            other.SendMessage("Watering");
        }
    }
}
