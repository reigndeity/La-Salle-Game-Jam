using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int points;
    public TextMeshProUGUI pointText;
    public float timer;
    public TextMeshProUGUI timerText;
    public int health;
    public TextMeshProUGUI healthText;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        pointText.text = points.ToString();
        timerText.text = timer.ToString();
        healthText.text = health.ToString();

        if (health <= 0)
        {
            //GameOver Function
        }
    }


}
