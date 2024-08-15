using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Main_Page ( in GameObject : CanvasMainPageButtons )

public class MainPage : MonoBehaviour
{
    public Text eventTittleUpdate;
    public GameObject eventButton;

    public string tournamentScene = "Tournament_Scene";

    private void Awake()
    {
        // Print event button in function there is an event now or not
        if (GameManager.instance.eventNow == false) return;
        else
        {
            eventTittleUpdate.text = GameManager.instance.eventTittle;
            eventButton.SetActive(true);
        }
    }

    //Launch Other Scene
    public void GuildButton(string levelName)
    {
        OpenPanels.instance.CloseAllPanel();
        SceneManager.LoadScene(levelName);
    }

    public void AdventureButton(string MapScene)
        {
        OpenPanels.instance.CloseAllPanel();
        GameManager.instance.inMapScene = true;
        GameManager.instance.numberOfZone = Biomes.instance.zonesList.Count;
        SceneManager.LoadScene(MapScene);
    }

    public void ActivitiesButton()
    {

    }

    public void TournamentButton()
    {
        OpenPanels.instance.CloseAllPanel();
        SceneManager.LoadScene(tournamentScene);
    }

    //Open Panel in MainPageScene
    public void CollectionButton()
    {
        OpenPanels.instance.CloseAllPanel();
        OpenPanels.instance.OpenCollectionPanel();
    }
    public void MarketButton()
    {
        OpenPanels.instance.CloseAllPanel();
        OpenPanels.instance.OpenMarketPanel();
    }

    public void QuestsButton()
    {
        OpenPanels.instance.CloseAllPanel();
        OpenPanels.instance.OpenQuestPanel();
    }


    public void RouletteButton()
    {
        OpenPanels.instance.CloseAllPanel();
        OpenPanels.instance.OpenRoulettePanel();
    }

    public void EventButton()
    {
        OpenPanels.instance.CloseAllPanel();
        OpenPanels.instance.OpenEventPanel();
    }

    public void AllianceButton()
    {

    }

    public void MoneyButton()
    {
        DataPlayer.instance.AddCoins(1);
    }
}
