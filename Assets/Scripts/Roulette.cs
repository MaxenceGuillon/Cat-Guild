using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Roulette : MonoBehaviour
{

    public int rouletteResult = -1;

    public List<CatData> listRewards = new List<CatData>();

    public GameObject openReward;

    public ModificationOfCollectionOfCats modificationOfCollectionOfCats;

    public Text nameNewCatUI;
    public Image visualNewCatUI;


    public static Roulette instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de Roulette dans la scène");
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
            nameNewCatUI.text = Roulette.instance.listRewards[3].nameOfCat;
            visualNewCatUI.sprite = Roulette.instance.listRewards[3].visual;
        }
        if ((rouletteResult >= 95) && (rouletteResult < 100))
        {
            modificationOfCollectionOfCats.AddCat(Roulette.instance.listRewards[3]);
            modificationOfCollectionOfCats.PrintNewCatUI(Roulette.instance.listRewards[3]);
            nameNewCatUI.text = Roulette.instance.listRewards[3].nameOfCat;
            visualNewCatUI.sprite = Roulette.instance.listRewards[3].visual;
        }

    }
}
