using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            SceneManager.LoadScene("GameScene");
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene("MainMenu");
        }

    }
    public void RestartButton(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Debug.Log("Restart or Main Menu");
    }
}
