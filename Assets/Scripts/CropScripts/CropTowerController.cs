using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropTowerController : MonoBehaviour
{
    [Header("Unity Setup")]
    private Transform targetDetected;
    private GameObject cropModel;
    private Transform firingPoint;
    
    public GameObject[] cropModelList;
    public Transform[] firingPointList;
    public GameObject bulletPrefab;

    //Header("Stats")//
    private float fireCountDown = 0f;
    private Crop towerStats;
    private float towerBonus = 1;

    public void AwakeTower(float tBonus, Crop tstat)
    {
        towerBonus = tBonus;
        towerStats = tstat;
        int towerID = towerStats.cropNumber;
        cropModelList[towerID].SetActive(true);
        cropModel = cropModelList[towerID];
        firingPoint = firingPointList[towerID];
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void Update() 
    {
        if(targetDetected == null)
        {
            return;
        }

        LockOnTarget();

        if (fireCountDown <= 0f)
        {
            Shoot();
            fireCountDown = 1f/(towerStats.cropFiringRate * towerBonus);
        }
        fireCountDown -= towerStats.cropBaseFiringRate;
    }

    void LockOnTarget()
    {
        Vector3 dir = targetDetected.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(cropModel.transform.rotation, lookRotation, Time.deltaTime * 5).eulerAngles;
        cropModel.transform.rotation = Quaternion.Euler (0f, rotation.y, 0f);
    }

    void Shoot()
    {
        GameObject bulletGameObject = (GameObject)Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
        CropBullet bullet = bulletGameObject.GetComponent<CropBullet>();

        if(bullet != null)
        {
            bullet.Seek(targetDetected);
            bullet.Store((towerStats.cropAttack * towerBonus));
        }
    }

    void UpdateTarget() //selects targets
    {
        GameObject[] bugsDetected = GameObject.FindGameObjectsWithTag("_Bug");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestBug = null;

        foreach (GameObject bugDetected in bugsDetected)
        {
            float distanceToBug = Vector3.Distance(transform.position, bugDetected.transform.position);

            if(distanceToBug < shortestDistance)
            {
                shortestDistance = distanceToBug;
                nearestBug = bugDetected;
            }
        }

        if(nearestBug != null && shortestDistance <= towerStats.cropRange)
        {
            targetDetected = nearestBug.transform;
        }
        else
        {
            targetDetected = null;
        }
    }
}
