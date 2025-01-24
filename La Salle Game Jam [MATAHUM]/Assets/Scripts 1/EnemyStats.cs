using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
    public bool canDie;

    [Header("Ingredients")]
    public int red;
    public int green;
    public int brown;
    public int purple;
    public Image[] flavors;
    public GameObject flavorHolder;

    public GameObject ingr_PopUp;

    private void Start()
    {
        Invoke("PopUp", 1);
    }

    private void Update()
    {
        if (canDie)
        {
            if(red == 0 && green == 0 && brown == 0 && purple == 0)
            {
                Destroy(this.gameObject);
                //points++;
            }
        }
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
        if (randomIngr == 0) red++;
        else if(randomIngr == 1) green++;
        else if(randomIngr == 2) brown++;
        else if(randomIngr == 3) purple++;
        Instantiate(flavors[randomIngr], flavorHolder.transform.position, Quaternion.identity, flavorHolder.transform);
        canDie = true;
    }
}
