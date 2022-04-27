using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject foodPrefabs;
    public GameObject ObstaclePrefab;
    public GameObject ObstaclePrefab2;

    private float spawnRange = 9;
    public int foodCount;

    
    void Update()
    {
        foodCount = FindObjectsOfType<Food>().Length;

        if (foodCount == 0)
        {
            SpawnFood();
            
        }
    }

    // Generate random Vector3 for spawning
    private Vector3 GenerateSpawnPos()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 1, spawnPosZ);

        return randomPos;

    }

    public void SpawnFood()
    {
        Instantiate(foodPrefabs, GenerateSpawnPos(), foodPrefabs.transform.rotation);
    }

    
}
