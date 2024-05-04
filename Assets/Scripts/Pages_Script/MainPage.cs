using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainPage : MonoBehaviour
{

    public GameObject panelEvent;
    public GameObject panelQuest;

    public void GuildButton(string levelName)
    {
        OpenPanels.instance.CloseAllPanel();
        SceneManager.LoadScene(levelName);
    }
    public void AdventureButton(string adventureName)
        {
        OpenPanels.instance.CloseAllPanel();
        SceneManager.LoadScene(adventureName);

    }
    public void CollectionButton()
    {
        OpenPanels.instance.CloseAllPanel();
        if (panelEvent == true) CloseEventPanel();
        if (panelQuest == true) CloseQuestPanel();
        OpenPanels.instance.OpenCollectionPanel();
    }

    public void ActivitiesButton()
    {

    }

    public void TournamentButton(string tournamentScene)
    {
        OpenPanels.instance.CloseAllPanel();
        SceneManager.LoadScene(tournamentScene);
    }

    public void MarketButton()
    {
        OpenPanels.instance.CloseAllPanel();
        if (panelEvent == true) CloseEventPanel();
        if (panelQuest == true) CloseQuestPanel();
        OpenPanels.instance.OpenMarketPanel();
    }

    public void QuestsButton()
    {
        OpenPanels.instance.CloseAllPanel();
        if (panelEvent == true) CloseEventPanel();
        if (panelQuest == true) CloseQuestPanel();
        panelQuest.SetActive(true);
    }

    public void CloseQuestPanel()
    {
        panelQuest.SetActive(false);
    }

    public void RouletteButton()
    {
        OpenPanels.instance.CloseAllPanel();
        if (panelEvent == true) CloseEventPanel();
        if (panelQuest == true) CloseQuestPanel();
        OpenPanels.instance.OpenRoulettePanel();
    }

    public void EventButton()
    {
        OpenPanels.instance.CloseAllPanel();
        if (panelEvent == true) CloseEventPanel();
        if (panelQuest == true) CloseQuestPanel();
        panelEvent.SetActive(true);
    }

    public void CloseEventPanel()
    {
        panelEvent.SetActive(false);
    }
    public void AllianceButton()
    {

    }

    public void MoneyButton()
    {
        DataPlayer.instance.AddCoins(1);
    }
}
