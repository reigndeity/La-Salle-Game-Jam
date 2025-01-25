using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
    public bool canDie;

    [Header("Ingredients")]
    public int red; //1
    public int green; //2
    public int brown; //3
    public int purple; //4

    public Image[] flavors;
    public GameObject flavorHolder;

    [Header("Pop-Up Properties")]
    public string enemySequence;
    public GameObject ingr_PopUp;

    private void Start()
    {
        Invoke("PopUp", 1);
    }

    private void Update()
    {
        // if (canDie)
        // {
        //     if(red == 0 && green == 0 && brown == 0 && purple == 0)
        //     {
        //         Destroy(this.gameObject);
        //         //points++;
        //     }
        // }
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
        if (randomIngr == 0) enemySequence += "1";//red++;
        else if(randomIngr == 1) enemySequence += "2";//green++;
        else if(randomIngr == 2) enemySequence += "3";//brown++;
        else if(randomIngr == 3) enemySequence += "4";//purple++;
        Instantiate(flavors[randomIngr], flavorHolder.transform.position, Quaternion.identity, flavorHolder.transform);
        canDie = true;
    }

    public void Die()
    {
        if(Spawner.instance.difficultyLevel == 1) GameManager.Instance.points+=25;
        else if (Spawner.instance.difficultyLevel == 2) GameManager.Instance.points+=50;
        else if (Spawner.instance.difficultyLevel == 3) GameManager.Instance.points+=100;
        Spawner.instance.SpawnEnemy();
        GameManager.Instance.timer += 3f;
        Destroy(gameObject);
    }
}
