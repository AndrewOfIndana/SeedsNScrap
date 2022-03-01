using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropBullet : MonoBehaviour
{
    private Transform targetedBug;
    public float speed = 70f;
    public GameObject kboom;
    private float thisAttack;


    public void Seek(Transform _target)
    {
        targetedBug = _target;
    }

    public void Store(float _attack)
    {
        thisAttack = _attack;
    }

    void FixedUpdate()
    {
        Vector3 dir;
        float distanceThisFrame = speed * Time.deltaTime;

        if (targetedBug == null)
        {
            transform.position += transform.forward * distanceThisFrame;
            transform.Translate(Vector3.up * Time.deltaTime, Space.World);
            Invoke("DestroyBullet", 5f);
            return;
        }
        else
        {
            dir = targetedBug.position - transform.position;
            transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("_Bug"))
        {
            other.gameObject.SendMessage("HitBug", thisAttack);
            Destroy(gameObject);
            GameObject boom = Instantiate(kboom, gameObject.transform.position, Quaternion.identity);
            Destroy(boom, 2f);
        }
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
