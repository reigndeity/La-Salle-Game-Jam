using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int points;
    public TMP_Text pointText;
    public float timer;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        pointText.text = points.ToString();
    }


}
