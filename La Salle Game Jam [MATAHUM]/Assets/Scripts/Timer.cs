using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public bool timerRunning = true;
    public TMP_Text timerText;
    void Update()
    {
        if (GameManager.Instance.isGameStart == true)
        {
            if (timerRunning)
            {
                if (GameManager.Instance.timer > 0)
                {
                    GameManager.Instance.timer  -= Time.deltaTime;
                    DisplayTime(GameManager.Instance.timer );
                }
                else
                {
                    GameManager.Instance.timer  = 0;
                    timerRunning = false;
                    DisplayTime(GameManager.Instance.timer );
                }
            }
        }
        else
        {
            Debug.Log("Game has not started yet!");
        }


    }

    void DisplayTime(float timeToDisplay)
    {   
        timeToDisplay += 1;
        int minutes = Mathf.FloorToInt(timeToDisplay / 60);
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
