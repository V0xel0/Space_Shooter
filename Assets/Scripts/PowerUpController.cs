using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    public GameEvent powerUpEvent;
    public float boostValue;
    private void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
        if (other.transform.root.GetComponent<PlayerController>() != null)
        {
            powerUpEvent.Raise(boostValue);
        }
    }
}