using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
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
    public float spawnFreq;
    public GameObject player;
    public SharedInt score;
    private bool isWaveActive;
    private GameState state = GameState.StartMenu;
    
    // Main game logic loop
    private void Update()
    {
        switch (state)
        {
            case GameState.StartMenu:
                isWaveActive = false;
                score.value = 0;
                if (Input.GetKey(KeyCode.W))
                {
                    player.SetActive(true);
                    state = GameState.Running;
                }
                return;
            case GameState.Running:
                if (isWaveActive == false)
                {
                    InvokeRepeating(nameof(StartSpawn), 2, spawnFreq);
                    isWaveActive = true;
                }
                if (!player.activeSelf)
                {
                    state = GameState.End;
                }
                break;
            case GameState.End:
                isWaveActive = false;
                if (Input.GetKey(KeyCode.R))
                {
                    state = GameState.StartMenu;
                }
                break;
        }
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
