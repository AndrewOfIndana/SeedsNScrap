using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTrigger : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("_Water"))
        {
            other.SendMessage("Refill");
        }
    }
}
