using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float fireRate;
    public Pooler bullets;
    
    public GameEvent onPowerUpFireRate;
    private float nextFire;

    private void Awake()
    {
        bullets.Init();
        onPowerUpFireRate.onEventRaisedFloat += boostFireRate;
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

    private void boostFireRate(float boost)
    {
        fireRate -= boost;
    }
}
