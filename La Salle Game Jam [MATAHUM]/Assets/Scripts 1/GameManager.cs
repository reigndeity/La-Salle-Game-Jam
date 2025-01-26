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

    [Header("Paused")]
    public bool isEscaped;
    public GameObject pausePanel;
    public TMP_Text currentPointText;
    public TMP_Text currentHighscoreText;
    public TMP_Text currentOrdersCompletedText;

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
        Time.timeScale = 1;
    }
    private void Update()
    {
        pointText.text = points.ToString();
        EscapedPanel();
        if (currentPressure >= 4) 
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

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (isEscaped)
            {
                pausePanel.SetActive(false);
                isEscaped = false;
                isGameStart = true;
                timerScript.timerRunning = true;
                Cursor.visible = false;
                Time.timeScale = 1;
            }
            else
            {
                pausePanel.SetActive(true);
                isEscaped = true;
                isGameStart = false;
                timerScript.timerRunning = false;
                Cursor.visible = true;
                Time.timeScale = 0;
            }
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
        AudioManager.instance.ReadySFX();
        yield return new WaitForSeconds(1);
        countdownTxt.text = "2";
        AudioManager.instance.ReadySFX();
        yield return new WaitForSeconds(1);
        countdownTxt.text = "1";
        AudioManager.instance.ReadySFX();
        yield return new WaitForSeconds(1);
        countdownTxt.text = "SHOOT!";
        AudioManager.instance.GoSFX();
        yield return new WaitForSeconds(1);
        AudioManager.instance.GameMusic();
        countdownTxt.enabled = false;
        isGameStart = true;
    }
    void GameOver()
    {
        AudioManager.instance.GameOverMusic();
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

    void EscapedPanel()
    {
        currentPointText.text = points.ToString();
        if (points > highscore)
        {
            highscore = points;
            PlayerPrefs.SetInt("Highscore", highscore);
            PlayerPrefs.Save();
        }
        currentHighscoreText.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
        currentOrdersCompletedText.text = ordersCompletedScore.ToString();
    }
}
