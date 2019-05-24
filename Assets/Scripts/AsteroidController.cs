using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public GameObject explosion;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        explosion = Instantiate(explosion);
        explosion.SetActive(false);
    }
    void Start()
    {
        rb.velocity = transform.forward * speed;
    }

    private void OnEnable()
    {
        explosion.SetActive(false);
    }

    private void OnDisable()
    {
        if(explosion == null)
            return;
        explosion.transform.position = transform.position;
        explosion.SetActive(true);
    }
}
