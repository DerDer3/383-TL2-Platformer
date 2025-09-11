using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public List<GameObject> powerupPrefabs;  
    public GameObject player;                
    public List<float> spawnX;
    public List<Vector3> spawnPositions;

    private int indexSpawnpoint = 0;

    public GenericSpawner genericSpawner;

    private void Update()
    {
        bool[] hasSpawned = new bool[spawnPositions.Count];

        for(int i = 0 ; i < powerupPrefabs.Count;i++)
        {
            if (!hasSpawned[i] && player.transform.position.x > spawnX[i])
            {
                SpawnRandomPowerup();
                hasSpawned[i] = true;
            }
        }
    }

    void SpawnRandomPowerup()
    {
        if(powerupPrefabs.Count == 0 || spawnPositions.Count == 0 || genericSpawner == null) { return; }

        int prefabsindex = Random.Range (0, powerupPrefabs.Count);
        //int indexSpawnpoint = Random.Range(0, spawnPositions.Count);

        genericSpawner.Spawn(powerupPrefabs[prefabsindex], spawnPositions[indexSpawnpoint], Quaternion.identity);
        indexSpawnpoint += 1;
    }
}

