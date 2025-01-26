using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject mainMenuConfirmation;
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
        AudioManager.instance.OnButtonClickSFX();
    }
    public void MenuButton()
    {
        mainMenuConfirmation.SetActive(true);
        AudioManager.instance.OnButtonClickSFX();
    }
    public void MenuButtonYes(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        AudioManager.instance.OnButtonClickSFX();
    }
    public void MenuButtonNo()
    {
        mainMenuConfirmation.SetActive(false);
        AudioManager.instance.OnButtonClickSFX();
    }
    public void GameOverMenu(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        AudioManager.instance.OnButtonClickSFX();
    }
}
