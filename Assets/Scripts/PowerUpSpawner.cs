using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public List<GameObject> powerupPrefabs;  
    public GameObject player;                
    public float spawnX = -5f;
    public List<Vector3> spawnPositions; 
    private bool hasSpawned = false;         

    private void Update()
    {
        if(!hasSpawned && player.transform.position.x > spawnX)
        {
            SpawnRandomPowerup();
            hasSpawned = true;
        }
    }

    void SpawnRandomPowerup()
    {
        if(powerupPrefabs.Count == 0 || spawnPositions.Count == 0) { return; }

        int  index = Random.Range (0, powerupPrefabs.Count);
        int indexSpawnpoint = Random.Range(0, spawnPositions.Count);

        Instantiate(powerupPrefabs[index], spawnPositions[indexSpawnpoint], Quaternion.identity);
    }
}

