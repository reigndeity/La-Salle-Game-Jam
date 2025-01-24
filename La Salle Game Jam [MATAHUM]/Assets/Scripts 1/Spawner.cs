using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner instance;
    public GameObject[] enemyPrefab;
    public GameObject[] spawnPoints;

    [Header("Spawn Variables")]
    public bool canSpawn;
    public float spawnTime;
    public int difficultyLevel;
    public int difficultyCounter;

    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        StartCoroutine(Spawn());
        
    }

    IEnumerator Spawn()
    {
        if(canSpawn)
        {
            canSpawn = false;
            yield return new WaitForSeconds(spawnTime);

            Instantiate(enemyPrefab[0], spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position, Quaternion.Euler(0,0,0), this.transform);
            spawnTime -= 0.01f;
            if(spawnTime <= 1) spawnTime = 1;
            difficultyCounter++;
            if (difficultyCounter % 10 == 0)
            {
                difficultyLevel++;
            }
            canSpawn = true;
        }
    }

    void SpawnEnemy()
    {
        
    }
}
