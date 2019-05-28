using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public GameEvent kill;
    public GameEvent dmgToPlayer;
    
    public Speed speed;
    public BaseDamage dmg;
    
    public GameObject explosion;
    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        explosion = Instantiate(explosion);
        explosion.SetActive(false);
    }
    void Start()
    {
        rb.velocity = transform.forward * speed.value;
    }

    private void OnEnable()
    {
        explosion.SetActive(false);
    }
    
    void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
        if (other.transform.root.GetComponent<ProjectileController>() != null)
        {
            other.gameObject.SetActive(false);
            kill.Raise();
            return;
        }
        if (other.transform.root.GetComponent<PlayerController>() != null)
        {
           dmgToPlayer.Raise(dmg.value);
        }
    }

    private void OnDisable()
    {
        if(explosion == null)
            return;
        explosion.transform.position = transform.position;
        explosion.SetActive(true);
    }
}
