using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class GameManagerController : MonoBehaviour
{
    public AsteroidSpawnerController hazardSpawner;
    private bool isWaveActive = true;

    public float spawnFreq;
    private void Start()
    {
        InvokeRepeating(nameof(StartSpawn), 2, spawnFreq);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isWaveActive)
        {
            CancelInvoke();
        }
    }

    void StartSpawn()
    {
        hazardSpawner.SpawnAsteroid();
    }
}
