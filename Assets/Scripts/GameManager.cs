using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string sceneToLoad;
    public int currentSceneNumber;


    public static GameManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance currentSceneNumber dans la scène");
            return;
        }
        instance = this;
    }

    public void SetSceneNumber(int number)
    {
        currentSceneNumber = number;
    }

    public void MainPageButton()
    {
        SceneManager.LoadScene(sceneToLoad);
        currentSceneNumber = 1;
    }

    
}
