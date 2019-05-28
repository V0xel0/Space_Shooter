using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float fireRate;
    //public RingBuffer bullets;\
    public Pooler bullets;
    private float nextFire;

    private void Awake()
    {
        bullets.Init();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!Input.GetButton("Fire1") || !(Time.time > nextFire)) return;
        nextFire = Time.time + fireRate;
        GameObject currBullet = bullets.GetNextObject();
        currBullet.transform.position = transform.position;
        currBullet.SetActive(true);
    }
}
