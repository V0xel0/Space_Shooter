using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public GameEvent kill;
    public GameEvent dmgToPlayer;
    
    public BaseDamage dmg;
    public GameObject explosion;

    void Awake()
    {
        explosion = Instantiate(explosion);
        explosion.SetActive(false);
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
