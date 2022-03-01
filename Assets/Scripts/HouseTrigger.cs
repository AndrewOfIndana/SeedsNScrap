using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseTrigger : MonoBehaviour
{
    public GameObject gManager;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("_Bug"))
        {
            gManager.SendMessage("LoseHealth");
        }
    }
}
