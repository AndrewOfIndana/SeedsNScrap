using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public GameObject cropPrefab;
    private Crop itemCropID;

    public void SetCrop(Crop _shoppingItemCrop)
    {
        itemCropID = _shoppingItemCrop;
    }

    void Plant()
    {    
        Destroy(gameObject);
        Vector3 newPosition = new Vector3(transform.position.x, (float)-1.6, transform.position.z);
        GameObject plantedCropObject = (GameObject)Instantiate(cropPrefab, newPosition, Quaternion.identity);
        CropContoller plantedCrop = plantedCropObject.GetComponent<CropContoller>();
        plantedCrop.SetCropStats(itemCropID);
    }

    void Grabbed()
    {
        this.GetComponent<Rigidbody>().useGravity = false;
        this.GetComponent<Rigidbody>().isKinematic = true;
    }

    void Dropped()
    {
        this.GetComponent<Rigidbody>().useGravity = true;
        this.GetComponent<Rigidbody>().isKinematic = false;
    }
}
