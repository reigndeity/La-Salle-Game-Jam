using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Points")]
    public int points;
    public int highscore;
    public TMP_Text pointText;
    public TMP_Text finalPointText;
    public TMP_Text highscoreText;

    [Header("Time")]
    public float timer;
    public Timer timerScript;

    [Header("Pressure Bar")]
    public Image pressureBarFill;
    public float currentPressure;
    public float maxPressure;

    [Header("Game Over")]
    public GameObject gameOver;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        timerScript = GetComponent<Timer>();
    }
    private void Update()
    {
        pointText.text = points.ToString();
        if(currentPressure >= 10) 
        {
            GameOver();
        }
    }
    public void AddPressure(float amount) 
    {
        currentPressure += amount;
        currentPressure = Mathf.Clamp(currentPressure, 0f, maxPressure);
        pressureBarFill.fillAmount = currentPressure / maxPressure;
    }

    void GameOver()
    {
        finalPointText.text = points.ToString();

        highscore = PlayerPrefs.GetInt("Highscore", 0);
        if (points > highscore) 
        {
            highscore = points;
            PlayerPrefs.SetInt("Highscore", highscore);
            PlayerPrefs.Save();
        }
        highscoreText.text = highscore.ToString();

        timerScript.timerRunning = false;

        gameOver.SetActive(true);
    }
}
