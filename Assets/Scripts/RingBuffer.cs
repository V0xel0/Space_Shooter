using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class RingBuffer
{
    public int poolAmount;
    public GameObject pooledObject;

    private List<GameObject> pooledObjects;
    private int activeIndex;

    //TODO:Check why unity is not calling constructor for this?, Init() is a workaround
    public void Init()
    {
        activeIndex = 0;
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < poolAmount; i++)
        {
            GameObject obj = Object.Instantiate(pooledObject);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }
       
    //Returning next object, and moving index
    public GameObject GetNextObject()
    {
        Debug.Log($"Size {pooledObjects.Count}");
        Debug.Log($"Current index {activeIndex}, pool {poolAmount}");
        int tempIndex = activeIndex;
        activeIndex = ++activeIndex % poolAmount;
        return pooledObjects[tempIndex];
    }
}
