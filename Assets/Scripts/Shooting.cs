using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private float nextFire;
    public float fireRate;
    public RingBuffer bullets;
    // Start is called before the first frame update
    private void Start()
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
