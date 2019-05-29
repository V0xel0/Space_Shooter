using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidSpawnerController : MonoBehaviour
{
    public Pooler[] asteroids;
    public int maxSpawnX;
    private void Awake()
    {
        foreach (var pool in asteroids)
        {
            pool.Init();
        }
    }

    public void SpawnAsteroid()
    {
        foreach (var pool in asteroids)
        {
            GameObject currAsteroid = pool.GetNextObject();
            var position = transform.position;
            currAsteroid.transform.position = new Vector3(Random.Range(-maxSpawnX, maxSpawnX), 
                position.y, position.z);
            currAsteroid.SetActive(true);
        }
    }
}