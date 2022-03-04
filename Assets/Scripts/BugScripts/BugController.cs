using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugController : MonoBehaviour
{
    public Bug[] bugStats;
    public GameObject[] bugPrefabs;

    private float bugLife;

    private Transform target;
    private int wavePointIndex = 0;
    
    private int randomBug;

    void Awake()
    {
        target = WayPoints.points[0];
    }

    void SetModel(int[] bugIdentity) 
    {
        randomBug = Random.Range(0, (bugIdentity.Length));
        int chosenBug = bugIdentity[randomBug];
        this.bugLife = bugStats[chosenBug].bugHealth;
        this.bugPrefabs[chosenBug].SetActive(true);
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * bugStats[randomBug].bugSpeed * Time.deltaTime, Space.World);
        transform.LookAt(WayPoints.points[wavePointIndex]);

        if (Vector3.Distance(transform.position, target.position) <= (bugStats[randomBug].bugSpeed * .01))
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if(wavePointIndex >= WayPoints.points.Length - 1)
        {
            Destroy(this.gameObject);
            return;
        }
        wavePointIndex++;
        target = WayPoints.points[wavePointIndex];
    }

    void DoDamage(float damage)
    {
        bugLife -= damage;
        if(bugLife <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
