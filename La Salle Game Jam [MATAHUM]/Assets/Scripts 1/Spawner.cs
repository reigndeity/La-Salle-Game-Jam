using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner instance;
    public GameObject[] enemyPrefab;
    public GameObject[] spawnPoints;
    public GameObject[] endPoints;

    [Header("Spawn Variables")]
    public bool canSpawn;
    public float spawnTime;
    public int difficultyLevel;
    public int difficultyCounter;
    public float speedMultiplier;

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

            int randomPoints = Random.Range(0, spawnPoints.Length);
            GameObject spawned = Instantiate(enemyPrefab[0], spawnPoints[randomPoints].transform.position, Quaternion.identity, this.transform);
            EnemyMovement enemyMovement = spawned.GetComponent<EnemyMovement>();

            speedMultiplier += 0.01f;
            enemyMovement.speed += speedMultiplier;
            if (enemyMovement.speed >= 5) enemyMovement.speed = 5f;

            spawnTime -= 0.01f;
            if(spawnTime <= 1) spawnTime = 1;
            difficultyCounter++;
            if (difficultyCounter % 10 == 0)
            {
                difficultyLevel++;
                if (difficultyLevel >= 3) difficultyCounter = 3;
            }
            canSpawn = true;
        }
    }

    void SpawnEnemy()
    {
        
    }
}
