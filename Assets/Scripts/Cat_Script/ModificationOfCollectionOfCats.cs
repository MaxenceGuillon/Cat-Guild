using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Loading_Scene ( in GameObject : CanvasItemsCats / CatCanvas ) 

public class ModificationOfCollectionOfCats : MonoBehaviour
{
    // Temporaly Cat instances to modifiate the player's cats collection
    public CatInstance newCatAdd;
    public CatInstance catInstanceTempo;
    public CatInstance newCurrentCat;

    // Boolean to confirm to add cat 
    public bool checker = false;

    // Print new cat instance informations UI in adventure
    public Text nameNewCatUI;
    public Text descriptionNewCatUI;
    public Image visualNewCatUI;

    // Print currents cat instance information UI in cats collection
    public Text currentCatName;
    public Text currentCatDescription;
    public Image currentCatVisual;
    public Text currentCatMoney;
    public Text currentCharmingStat;
    public Text currentProcrastinatorStat;
    public Text currentAdventurousStat;

    public CollectionOfCats collectionOfCats;

    // Print New add cat panel when player find a cat in adventure
    public void PrintNewCatUI(CatData newCatReady)
    {
        nameNewCatUI.text = newCatReady.nameOfCat;
        descriptionNewCatUI.text = newCatReady.descriptionOfCat;
        visualNewCatUI.sprite = newCatReady.visual;
    }

    // Print first cat instance in player's cats collection 
    public void PrintFirstCatIU()
    {
        if (CollectionOfCats.instance.catsCollectionContent.Count == 0) return;

        currentCatName.text = CollectionOfCats.instance.catsCollectionContent[0].cat.nameOfCat;
        currentCatDescription.text = CollectionOfCats.instance.catsCollectionContent[0].cat.descriptionOfCat;
        currentCatVisual.sprite = CollectionOfCats.instance.catsCollectionContent[0].cat.visual;
        currentCatMoney.text = CollectionOfCats.instance.catsCollectionContent[0].cat.moneyWin.ToString() + " / h";
        currentCharmingStat.text = CollectionOfCats.instance.catsCollectionContent[0].charming.ToString();
        currentProcrastinatorStat.text = CollectionOfCats.instance.catsCollectionContent[0].procrastinator.ToString();
        currentAdventurousStat.text = CollectionOfCats.instance.catsCollectionContent[0].adventurous.ToString();
    }

    // Print current cat in player's cats collection
    public void PrintCatIU(int indexOfButton)
    {
        currentCatName.text = CollectionOfCats.instance.catsCollectionContent[indexOfButton].cat.nameOfCat;
        currentCatDescription.text = CollectionOfCats.instance.catsCollectionContent[indexOfButton].cat.descriptionOfCat;
        currentCatVisual.sprite = CollectionOfCats.instance.catsCollectionContent[indexOfButton].cat.visual;
        currentCatMoney.text = CollectionOfCats.instance.catsCollectionContent[indexOfButton].cat.moneyWin.ToString() + " / h";
        currentCharmingStat.text = CollectionOfCats.instance.catsCollectionContent[indexOfButton].charming.ToString();
        currentProcrastinatorStat.text = CollectionOfCats.instance.catsCollectionContent[indexOfButton].procrastinator.ToString();
        currentAdventurousStat.text = CollectionOfCats.instance.catsCollectionContent[indexOfButton].adventurous.ToString();
    }

    public void AddCat(CatData newCat)
    {
        if (collectionOfCats.IsFull() == true)
        {
            Debug.Log("Collection full, can't take : " + newCat.name);
            return;
        }

        // Creation of new cat instance stats
        catInstanceTempo.cat = newCat;
        catInstanceTempo.charming = Random.Range(newCat.charmingMin, newCat.charmingMax);
        catInstanceTempo.procrastinator = Random.Range(newCat.procrastinatorMin, newCat.procrastinatorMax);
        catInstanceTempo.adventurous = Random.Range(newCat.adventurousMin, newCat.adventurousMax);

        // Create and add cat instance in player's collection
        CollectionOfCats.instance.catsCollectionContent.Add(newCurrentCat = ScriptableObject.CreateInstance<CatInstance>());
        newCurrentCat.cat = newCat;
        newCurrentCat.charming = catInstanceTempo.charming;
        newCurrentCat.procrastinator = catInstanceTempo.procrastinator;
        newCurrentCat.adventurous = catInstanceTempo.adventurous;

        DeterminateAlphaBetaOmegaCurrentCatInstanceStats(newCurrentCat);

        collectionOfCats.RefreshCollectionOfCats();
    }

    void DeterminateAlphaBetaOmegaCurrentCatInstanceStats(CatInstance currentCat)
    {
        //Determinate alphaStat of current cat
        if ((currentCat.charming > currentCat.procrastinator) && (currentCat.charming > currentCat.adventurous))
        {
            currentCat.alphaStat = currentCat.charming;
        }
        else
        {
            if ((currentCat.procrastinator > currentCat.charming) && (currentCat.procrastinator > currentCat.adventurous))
            {
                currentCat.alphaStat = currentCat.procrastinator;
            }
            else
            {
                currentCat.alphaStat = currentCat.adventurous;
            }
        }

        //Determinate betaStat of current cat
        if (((currentCat.charming > currentCat.procrastinator) && (currentCat.charming < currentCat.adventurous)) || ((currentCat.charming < currentCat.procrastinator) && (currentCat.charming > currentCat.adventurous)))
        {
            currentCat.betaStat = currentCat.charming;
        }
        else
        {
            if (((currentCat.procrastinator > currentCat.charming) && (currentCat.procrastinator < currentCat.adventurous)) || ((currentCat.procrastinator < currentCat.charming) && (currentCat.procrastinator > currentCat.adventurous)))
            {
                currentCat.betaStat = currentCat.procrastinator;
            }
            else
            {
                currentCat.betaStat = currentCat.adventurous;
            }
        }

        //Determinate omegaStat of current cat
        if ((currentCat.charming < currentCat.procrastinator) && (currentCat.charming < currentCat.adventurous))
        {
            currentCat.omegaStat = currentCat.charming;
        }
        else
        {
            if ((currentCat.procrastinator < currentCat.charming) && (currentCat.procrastinator < currentCat.adventurous))
            {
                currentCat.omegaStat = currentCat.procrastinator;
            }
            else
            {
                currentCat.omegaStat = currentCat.adventurous;
            }
        }
        //Debug.Log("AlphaStat of " + currentCat.cat.nameOfCat + " = " + currentCat.alphaStat);
        //Debug.Log("BetaStat of " + currentCat.cat.nameOfCat + " = " + currentCat.betaStat);
        //Debug.Log("OmegaStat of " + currentCat.cat.nameOfCat + " = " + currentCat.omegaStat);
    }

    void Update()
    {
        if (checker == true)
        {
            AddCat(newCatAdd.cat);
            checker = false;
            PrintNewCatUI(newCatAdd.cat);
        }
    }
}
