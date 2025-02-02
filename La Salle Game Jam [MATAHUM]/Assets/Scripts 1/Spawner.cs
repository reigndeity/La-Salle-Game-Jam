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
    public bool spawnOnce;

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
        if (GameManager.Instance.isGameStart == true)
        {
            if(spawnOnce == false)
            {
                SpawnEnemy();
                spawnOnce = true;
            }
            if (canSpawn)
            {
                canSpawn = false;
                yield return new WaitForSeconds(spawnTime);

                SpawnEnemy();

                canSpawn = true;
            }
        }
        else
        {
            Debug.Log("Can't spawn yet!");
        }

    }

    public void SpawnEnemy()
    {
        int randomPoints = Random.Range(0, spawnPoints.Length);

        // Spawn the enemy
        GameObject spawned = Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Length)], spawnPoints[randomPoints].transform.position, Quaternion.identity, this.transform);
        
        AudioManager.instance.SpawnSFX();

        // Assign the corresponding endpoint as the target
        EnemyMovement enemyMovement = spawned.GetComponent<EnemyMovement>();
        if (enemyMovement != null)
        {
            enemyMovement.target = endPoints[randomPoints]; // Set the endpoint as the target
        }

        // Adjust speed and spawn time   
        if (difficultyLevel == 1) speedMultiplier = 0;
        else if (difficultyLevel == 2) speedMultiplier += 0.02f;
        else if (difficultyLevel == 3) speedMultiplier += 0.045f;

        enemyMovement.speed += speedMultiplier;
        if (enemyMovement.speed >= 5) enemyMovement.speed = 5f;
    }

    public void IncreaseDifficulty()
    {
        difficultyCounter++;
        if (difficultyCounter % 10 == 0)
        {
            difficultyLevel++;
            if (difficultyLevel >= 3) difficultyLevel = 3;
        }

        if (difficultyLevel == 2) spawnTime -= 0.05f;
        else if (difficultyLevel == 3) spawnTime -= 0.12f;

        if (spawnTime <= 2) spawnTime = 2;
    }

}
