using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Loading_Scene ( in GameObject : CanvasPanelUI / PanelManager / RoulettePanel ) 

public class Roulette : MonoBehaviour
{
    public int rouletteResult = -1; // State machine variable of roulette

    public List<CatData> listRewards = new List<CatData>(); // List of cats avaible in part of roulette "cats"

    // UI Roulette reward
    public Text nameNewCatUI;
    public Image visualNewCatUI;

    public ModificationOfCollectionOfCats modificationOfCollectionOfCats;
    public PrintCurrentEvent printCurrentEvent;
    public AnimationPanelEventPointWin animationPanelEventPointWin;


    public static Roulette instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de Roulette dans la sc�ne");
            return;
        }
        instance = this;
    }

    public void LauchRoulette()
    {
        rouletteResult = Random.Range(1, 100);

        if ((rouletteResult >= 0)&& (rouletteResult < 50))
        {
            modificationOfCollectionOfCats.AddCat(Roulette.instance.listRewards[0]);
            modificationOfCollectionOfCats.PrintNewCatUI(Roulette.instance.listRewards[0]);
            nameNewCatUI.text = Roulette.instance.listRewards[0].nameOfCat;
            visualNewCatUI.sprite = Roulette.instance.listRewards[0].visual;
        }
        if ((rouletteResult >= 50) && (rouletteResult < 80))
        {
            modificationOfCollectionOfCats.AddCat(Roulette.instance.listRewards[1]);
            modificationOfCollectionOfCats.PrintNewCatUI(Roulette.instance.listRewards[1]);
            nameNewCatUI.text = Roulette.instance.listRewards[1].nameOfCat;
            visualNewCatUI.sprite = Roulette.instance.listRewards[1].visual;
        }
        if ((rouletteResult >= 80) && (rouletteResult < 95))
        {
            modificationOfCollectionOfCats.AddCat(Roulette.instance.listRewards[2]);
            modificationOfCollectionOfCats.PrintNewCatUI(Roulette.instance.listRewards[2]);
            nameNewCatUI.text = Roulette.instance.listRewards[2].nameOfCat;
            visualNewCatUI.sprite = Roulette.instance.listRewards[2].visual;
        }
        if ((rouletteResult >= 95) && (rouletteResult < 100))
        {
            modificationOfCollectionOfCats.AddCat(Roulette.instance.listRewards[3]);
            modificationOfCollectionOfCats.PrintNewCatUI(Roulette.instance.listRewards[3]);
            nameNewCatUI.text = Roulette.instance.listRewards[3].nameOfCat;
            visualNewCatUI.sprite = Roulette.instance.listRewards[3].visual;
        }

        // Case : There is event now and add event points in function
        if (GameManager.instance.eventNow == true) DataPlayer.instance.EventPointWin(printCurrentEvent.roulettePoint);

        if ((GameManager.instance.eventNow == true) && (animationPanelEventPointWin.lockToMainAnim == false)) printCurrentEvent.PrintPanelEventPointsWin(printCurrentEvent.roulettePoint);
    }
}
