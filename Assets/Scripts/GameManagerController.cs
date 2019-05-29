using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

enum GameState
{
    StartMenu,
    Running,
    End
}

public class GameManagerController : MonoBehaviour
{
    public AsteroidSpawnerController hazardSpawner;
    public PowerUpsSpawnerController powerUpsSpawner;

    public GameObject player;
    public SharedInt score;
    
    public float spawnFreq;
  
    private bool isWaveActive;
    private GameState state = GameState.StartMenu;
    private void Update()
    {
        switch (state)
        {
            case GameState.StartMenu:
                isWaveActive = false;
                score.value = 0;
                if (Input.GetKey(KeyCode.W))
                {
                    state = GameState.Running;
                }
                break;
            case GameState.Running:
                if (isWaveActive == false)
                {
                    InvokeRepeating(nameof(SpawnHazards), 2, spawnFreq);
                    InvokeRepeating(nameof(SpawnPowerUps), 6, spawnFreq*4);
                    isWaveActive = true;
                }
                if (!player.activeSelf)
                {
                    CancelInvoke();
                    state = GameState.End;
                }
                break;
            case GameState.End:
                isWaveActive = false;
                if (Input.GetKey(KeyCode.R))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                    state = GameState.StartMenu;
                }
                break;
        }
    }

    private void SpawnHazards()
    {
        hazardSpawner.SpawnAsteroid();
    }

    private void SpawnPowerUps()
    {
        powerUpsSpawner.SpawnPowerUp();

    }
}
