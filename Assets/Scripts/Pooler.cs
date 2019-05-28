using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pooler
{
    public int poolAmount;
    public GameObject typeToPool;
    
    private List<GameObject> pooledObjects;
    private int indexLast;
    private int activeIndex;
    private int toResize;
    
    public void Init()
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < poolAmount; i++)
        {
            GameObject obj = Object.Instantiate(typeToPool);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }

        indexLast = pooledObjects.Count - 1;
        activeIndex = 0;
        toResize = 10;
    }

    public GameObject GetNextObject()
    {
        if (activeIndex == indexLast && pooledObjects[activeIndex/2].activeSelf)
        {
            //Add more objects
            for (int i = 0; i < toResize; i++)
            {
                GameObject obj = Object.Instantiate(typeToPool);
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
            indexLast = pooledObjects.Count - 1;
        }
        int tempIndex = activeIndex;
        activeIndex = ++activeIndex % (indexLast+1);
        return pooledObjects[tempIndex];
    }
}