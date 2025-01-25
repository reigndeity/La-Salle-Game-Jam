using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [Header("Game Properties")]
    public bool isGameStart;
    public TextMeshProUGUI countdownTxt;

    [Header("Points")]
    public int points;
    public int highscore;
    public int ordersCompletedScore;
    public TMP_Text pointText;
    public TMP_Text finalPointText;
    public TMP_Text highscoreText;
    public TMP_Text ordersCompletedText;

    [Header("Time")]
    public float timer;
    public Timer timerScript;

    [Header("Pressure Bar")]
    public float currentPressure;
    public float maxPressure;
    public GameObject[] pressureObjs;

    [Header("Game Over")]
    public GameObject gameOver;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        timerScript = GetComponent<Timer>();
        StartCoroutine(GameStart());
    }
    private void Update()
    {
        pointText.text = points.ToString();
        if(currentPressure >= 4) 
        {
            GameOver();
        }

        switch (currentPressure)
        {
            case 0:
                pressureObjs[0].SetActive(true);
                break;
            case 1:
                pressureObjs[0].SetActive(false);
                pressureObjs[1].SetActive(true);
                break;
            case 2:
                pressureObjs[1].SetActive(false);
                pressureObjs[2].SetActive(true);
                break;
            case 3:
                pressureObjs[2].SetActive(false);
                pressureObjs[3].SetActive(true);
                break;
            case 4:
                pressureObjs[3].SetActive(false);
                pressureObjs[4].SetActive(true);
                break;
        }
    }
    public void AddPressure(float amount) 
    {
        currentPressure += amount;
        currentPressure = Mathf.Clamp(currentPressure, 0f, maxPressure);
    }

    IEnumerator GameStart()
    {
        Cursor.visible = false;
        isGameStart = false;
        countdownTxt.enabled = true;
        countdownTxt.text = "3";
        yield return new WaitForSeconds(1);
        countdownTxt.text = "2";
        yield return new WaitForSeconds(1);
        countdownTxt.text = "1";
        yield return new WaitForSeconds(1);
        countdownTxt.text = "SHOOT!";
        yield return new WaitForSeconds(1);
        countdownTxt.enabled = false;
        isGameStart = true;
    }
    void GameOver()
    {
        Cursor.visible = true;
        finalPointText.text = points.ToString();
        highscore = PlayerPrefs.GetInt("Highscore", 0);
        if (points > highscore) 
        {
            highscore = points;
            PlayerPrefs.SetInt("Highscore", highscore);
            PlayerPrefs.Save();
        }
        highscoreText.text = highscore.ToString();

        ordersCompletedText.text = ordersCompletedScore.ToString();

        timerScript.timerRunning = false;

        gameOver.SetActive(true);

        isGameStart = false;
    }
}
