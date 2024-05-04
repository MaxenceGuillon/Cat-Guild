using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public string sceneToLoad;
    public int currentSceneNumber;

    public OpenPanels openPanels;



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
        if(openPanels.panelCollection == true)
        {
            openPanels.CloseCollectionPanel();
        }
        if(openPanels.panelMarket == true)
        {
            openPanels.CloseMarketPanel();
        }
        if(openPanels.panelRoulette == true)
        {
            openPanels.CloseRoulettePanel();
        }

        SceneManager.LoadScene(sceneToLoad);
        currentSceneNumber = 1;
    }
}
