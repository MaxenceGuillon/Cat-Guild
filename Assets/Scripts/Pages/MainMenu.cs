using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad;
    public GameObject settingsWindow;
    public void StartGame()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void SettingsButton()
    {
        settingsWindow.SetActive(true);
    }

    public void CloseSettingsWindow()
    {
        settingsWindow.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
