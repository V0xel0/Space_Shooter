﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    
    public CommonEnum colType;
    void OnTriggerEnter()
    {
        colType.type = EnumTag.Bullet;
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        rb.velocity = transform.forward * speed;
    }
}
