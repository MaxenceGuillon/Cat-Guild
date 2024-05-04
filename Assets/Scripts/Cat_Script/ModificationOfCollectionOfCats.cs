using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class ModificationOfCollectionOfCats : MonoBehaviour
{
    public CatInstance newCatAdd;
    public CatInstance catInstanceTempo;
    public CatInstance newCatTest;

    public bool checker = false;
    public bool openReward = false;

    public Text nameNewCatUI;
    public Text descriptionNewCatUI;
    public Image visualNewCatUI;

    public Text currentCatName;
    public Text currentCatDescription;
    public Image currentCatVisual;
    public Text currentCatMoney;
    public Text currentCharmingStat;
    public Text currentProcrastinatorStat;
    public Text currentAdventurousStat;

    public GameObject openWindow;
    public GameObject closeWindow;

    public CollectionOfCats collectionOfCats;

    private void Start()
    {
       
    }

    public void PrintNewCatUI(CatData newCatReady)
    {
        nameNewCatUI.text = newCatReady.nameOfCat;
        descriptionNewCatUI.text = newCatReady.descriptionOfCat;
        visualNewCatUI.sprite = newCatReady.visual;
    }

    public void PrintFirstCatIU()
    {
        if (CollectionOfCats.instance.contentOfCollectionsOfCats.Count == 0)
        {
            return;
        }
        currentCatName.text = CollectionOfCats.instance.contentOfCollectionsOfCats[0].cat.nameOfCat;
        currentCatDescription.text = CollectionOfCats.instance.contentOfCollectionsOfCats[0].cat.descriptionOfCat;
        currentCatVisual.sprite = CollectionOfCats.instance.contentOfCollectionsOfCats[0].cat.visual;
        currentCatMoney.text = CollectionOfCats.instance.contentOfCollectionsOfCats[0].cat.moneyWin.ToString() + " / h";
        currentCharmingStat.text = CollectionOfCats.instance.contentOfCollectionsOfCats[0].charming.ToString();
        currentProcrastinatorStat.text = CollectionOfCats.instance.contentOfCollectionsOfCats[0].procrastinator.ToString();
        currentAdventurousStat.text = CollectionOfCats.instance.contentOfCollectionsOfCats[0].adventurous.ToString();
    }

    public void PrintCatIU(int indexOfButton)
    {
        currentCatName.text = CollectionOfCats.instance.contentOfCollectionsOfCats[indexOfButton].cat.nameOfCat;
        currentCatDescription.text = CollectionOfCats.instance.contentOfCollectionsOfCats[indexOfButton].cat.descriptionOfCat;
        currentCatVisual.sprite = CollectionOfCats.instance.contentOfCollectionsOfCats[indexOfButton].cat.visual;
        currentCatMoney.text = CollectionOfCats.instance.contentOfCollectionsOfCats[indexOfButton].cat.moneyWin.ToString() + " / h";
        currentCharmingStat.text = CollectionOfCats.instance.contentOfCollectionsOfCats[indexOfButton].charming.ToString();
        currentProcrastinatorStat.text = CollectionOfCats.instance.contentOfCollectionsOfCats[indexOfButton].procrastinator.ToString();
        currentAdventurousStat.text = CollectionOfCats.instance.contentOfCollectionsOfCats[indexOfButton].adventurous.ToString();
    }
    public void AddCat(CatData newCat)
    {

        if (collectionOfCats.IsFull() == true)
        {
            Debug.Log("Collection full, can't take : " + newCat.name);
            return;
        }

        catInstanceTempo.cat = newCat;
        catInstanceTempo.charming = Random.Range(newCat.charmingMin, newCat.charmingMax);
        catInstanceTempo.procrastinator = Random.Range(newCat.procrastinatorMin, newCat.procrastinatorMax);
        catInstanceTempo.adventurous = Random.Range(newCat.adventurousMin, newCat.adventurousMax);

        
        CollectionOfCats.instance.contentOfCollectionsOfCats.Add(newCatTest = ScriptableObject.CreateInstance<CatInstance>());
        newCatTest.cat = newCat;
        newCatTest.charming = catInstanceTempo.charming;
        newCatTest.procrastinator = catInstanceTempo.procrastinator;
        newCatTest.adventurous = catInstanceTempo.adventurous;

        collectionOfCats.RefreshCollectionOfCats();
    }


    void Update()
    {
        if (checker == true)
        {
            AddCat(newCatAdd.cat);
            checker = false;
            PrintNewCatUI(newCatAdd.cat);
            openReward = true;
        }

        if (openReward == true)
        {
            openWindow.SetActive(true);
            openReward = false;
        }
    }
    public void CloseWindow()
    {
        closeWindow.SetActive(false);
    }
    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
