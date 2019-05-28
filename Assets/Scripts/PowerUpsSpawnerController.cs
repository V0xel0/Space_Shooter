using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PowerUpsSpawnerController : MonoBehaviour
{
    public RingBuffer powerUps;
    public int maxSpawnX;
    
    private Rigidbody rb;
    private void Awake()
    {
        powerUps.Init();
    }
 
    public void SpawnPowerUp()
    {
        GameObject currPowerUp = powerUps.GetNextObject();
        var position = transform.position;
        currPowerUp.transform.position = new Vector3(Random.Range(-maxSpawnX, maxSpawnX), 
            position.y, position.z);
        currPowerUp.SetActive(true);
    }
}
