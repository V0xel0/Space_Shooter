using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelChanger : MonoBehaviour
{
    public GameObject[] models;
    public SharedInt score;
    [SerializeField]
    private int currentlyActive;
    [SerializeField]
    private int changeStep;

    private int innerScore;
    //TODO:Change it later to receive msg from external system

    private void Start()
    {
        models[currentlyActive].SetActive(true);
    }

    public void Update()
    {
        //After every x points change to next skin
        if (score.value != innerScore + changeStep || currentlyActive == models.Length - 1) return;
        models[currentlyActive].SetActive(false);
        currentlyActive++;
        models[currentlyActive].SetActive(true);
        innerScore = score.value;
    }
}
