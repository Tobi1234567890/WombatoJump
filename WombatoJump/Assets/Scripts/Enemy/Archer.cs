using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Enemy
{

    [SerializeField]
    public GameObject Bullet;

    public float FireRate;
    private float nextFire;

    void Start()
    {
        nextFire = Time.time;
        StartCoroutine(ShootBulletAfterTime());
    }


    private void CheckIfTimeToFire()
    {
        if(Time.time > nextFire)
        {
            Instantiate(Bullet, transform.position, Quaternion.identity);
            nextFire = Time.time + FireRate;
        }
    }

    private IEnumerator ShootBulletAfterTime()
    {
        yield return new WaitForSeconds(FireRate);
        Instantiate(Bullet, transform.position, Quaternion.identity);
        StartCoroutine(ShootBulletAfterTime());
    }
}
