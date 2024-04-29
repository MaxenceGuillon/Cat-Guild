using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainPage : MonoBehaviour
{

    public GameObject settingsWindow;
    public void LoadLevel( string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
    public void AdventureButton(string adventureName)
    {
        SceneManager.LoadScene(adventureName);

    }
    public void CollectionButton()
    {
        OpenPanels.instance.OpenCollectionPanel();
    }

    public void ActivitiesButton()
    {

    }

    public void TournamentButton()
    {

    }

    public void MarketButton()
    {

    }

    public void QuestsButton()
    {

    }

    public void RouletteButton()
    {
        OpenPanels.instance.OpenRoulettePanel();
    }

    public void EventButton()
    {

    }

    public void AllianceButton()
    {

    }

    public void MoneyButton()
    {
        Inventory.instance.AddCoins(1);
    }
}
