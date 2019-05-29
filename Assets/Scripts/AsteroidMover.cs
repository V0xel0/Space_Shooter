using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Currently implemented in a way that every enable increases multi by one
public class AsteroidMover : MonoBehaviour
{
  public Speed baseSpeed;
  public float baseMultiplier;
  public float multiStepIncrease;
  
  private Rigidbody rb;
  private void Awake()
  {
    rb = GetComponent<Rigidbody>();
  }
  private void OnEnable()
  {
    baseMultiplier += multiStepIncrease;
    rb.velocity = baseSpeed.value * baseMultiplier * Vector3.forward; 
  }
}