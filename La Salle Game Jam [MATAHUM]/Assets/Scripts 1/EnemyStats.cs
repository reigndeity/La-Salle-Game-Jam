using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
    public bool canDie;

    [Header("Ingredients")]
    public int blue; //1
    public int red; //2
    public int green; //3
    public int purple; //4

    public GameObject[] flavors;
    public GameObject flavorHolder;

    [Header("Pop-Up Properties")]
    public string enemySequence;
    public GameObject ingr_PopUp;

    private EnemyMovement _enemyMovement;
    private void Start()
    {
        Invoke("PopUp", 1);
        _enemyMovement = GetComponent<EnemyMovement>();
    }

    void PopUp()
    {
        ingr_PopUp.SetActive(true);
        for (int i = 0; i < Spawner.instance.difficultyLevel; i++) 
        {
            Randomizer();
        }
        Debug.Log("PopUp");
    }

    void Randomizer()
    {
        int randomIngr = Random.Range(0, 4);
        if (randomIngr == 0) enemySequence += "1";//blue++;
        else if(randomIngr == 1) enemySequence += "2";//red++;
        else if(randomIngr == 2) enemySequence += "3";//green++;
        else if(randomIngr == 3) enemySequence += "4";//purple++;
        Instantiate(flavors[randomIngr], flavorHolder.transform.position, Quaternion.identity, flavorHolder.transform);
        canDie = true;
        Debug.Log("Added ingredient");
    }

    public void Die()
    {
        if(Spawner.instance.difficultyLevel == 1) GameManager.Instance.points+=25;
        else if (Spawner.instance.difficultyLevel == 2) GameManager.Instance.points+=50;
        else if (Spawner.instance.difficultyLevel == 3) GameManager.Instance.points+=100;
        Spawner.instance.SpawnEnemy();
        GameManager.Instance.timer += 3f;
        _enemyMovement.Catch();
        
    }
}
