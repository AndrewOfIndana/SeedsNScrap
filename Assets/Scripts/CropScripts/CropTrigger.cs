using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropTrigger : MonoBehaviour
{
    void HitCrop()
    {
        this.gameObject.SendMessageUpwards("SellCrop");
    }
}
