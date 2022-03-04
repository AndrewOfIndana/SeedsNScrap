using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerToolGun : MonoBehaviour
{
    private float FiringRate = 3f;
    private float NextFire;
    private int doubleShot = 0;
    public Transform shootStart;
    public GameObject shootBeam;

    bool canShoot = true;
    float shootReset = .2f;
    public GameObject kboom;


    void Update()
    {        
        if(Input.GetButtonDown("Fire1")  && canShoot && Time.time > NextFire) 
        {
            shootBeam.SetActive(true);

            Ray r = new Ray(shootStart.position, shootStart.forward);
            RaycastHit hit;
            if( Physics.Raycast(r, out hit) )
            {
                if( hit.collider.CompareTag("_Bug") )
                {
                    hit.collider.gameObject.SendMessage("HitBug", 1);

                    GameObject boom = Instantiate(kboom, hit.point, Quaternion.identity);
                    Destroy(boom, 2f);
                }
            }

            if(doubleShot >= 1)
            {
                NextFire = Time.time + FiringRate;
                doubleShot = 0;
            }
            else
            {
                doubleShot++;
            }

            canShoot = false;
            Invoke("ResetBeam", shootReset);

        }
    }

    void ResetBeam()
    {
        canShoot = true;
        shootBeam.SetActive(false);
    }

}
