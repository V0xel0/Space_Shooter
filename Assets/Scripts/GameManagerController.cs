using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

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
    private bool isWaveActive = false;
    private GameState state = GameState.StartMenu;
    
    // Main game logic loop
    private void Update()
    {
        switch (state)
        {
            case GameState.StartMenu:
                isWaveActive = false;
                if (Input.GetKey(KeyCode.W))
                {
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
