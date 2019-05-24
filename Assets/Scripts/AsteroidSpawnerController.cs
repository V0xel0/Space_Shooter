using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidSpawnerController : MonoBehaviour
{
    public RingBuffer asteroids;
    public int maxSpawnX;
    private void Awake()
    {
        asteroids.Init();
    }

    public void SpawnAsteroid()
    {
        GameObject currAsteroid = asteroids.GetNextObject();
        var position = transform.position;
        currAsteroid.transform.position = new Vector3(Random.Range(-maxSpawnX, maxSpawnX), 
                                            position.y, position.z);
        currAsteroid.SetActive(true);
    }
}