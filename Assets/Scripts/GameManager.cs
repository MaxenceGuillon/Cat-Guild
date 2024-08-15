using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Loading_Scene ( in GameObject : GameManager )

public class GameManager : MonoBehaviour
{
    public string sceneToLoad;

    public bool toMainPage = false;
    public int iDZoneChoose;
    public int numberOfZone;

    public bool inLoadingScene = true;

    public List<bool> zonesUnlockList = new List<bool>();

    public bool dialogueNotFinish = false;
    public bool inAdventureScene = false;
    public bool inMapScene = false;

    public int idCurrentEvent;
    public bool eventNow = false;
    public string eventTittle;


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

    //Method necessary to choose if continue button in Adventure_Scene send player in Main page or not
    public void SetBoolToMainPage()
    {
        toMainPage = true;
    }

    // Method to come back in Main_Page and reset all variable in function
    public void MainPageButton()
    {
        if (toMainPage)
        {
            openPanels.CloseAllPanel();

            // Case : The player use the button BackToMainPageButton without finishing the current dialogue
            if ((inAdventureScene == true) && (DialogueManager.instance.sentencesNumberTempo != 0) && (DialogueManager.instance.sentencesRead > 0)) dialogueNotFinish = true;
            if (inAdventureScene)
            {
                DialogueManager.instance.lockDoubleCatAdd.SetActive(false);
                DialogueManager.instance.panelNewCat.SetActive(false);
            }
            inAdventureScene = false;

            if (inMapScene)
            {
                inMapScene = false;
            }

            SceneManager.LoadScene(sceneToLoad);

            toMainPage = false;
        } 
    }

    public void Update()
    {
        // Update to unlock zone in function of ZoneList
        if ((inMapScene == true) && (zonesUnlockList.Count != numberOfZone))
        {
            for (int i = 0; i < numberOfZone; i++)
            {
                zonesUnlockList.Add(Biomes.instance.zonesList[i].unlockBool);
            }
        }
    }
}
