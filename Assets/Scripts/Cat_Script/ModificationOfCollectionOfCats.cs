using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class ModificationOfCollectionOfCats : MonoBehaviour
{
    public CatID newCatAdd;
    public string tempoDescriptionCat;
    public bool checker = false;
    public bool openReward = false;

    public Text nameNewCatUI;
    public Text descriptionNewCatUI;
    public Image visualNewCatUI;

    public Text currentCatName;
    public Text currentCatDescription;
    public Image currentCatVisual;

    public GameObject openWindow;
    public GameObject closeWindow;

    public CollectionOfCats collectionOfCats;
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
        currentCatName.text = CollectionOfCats.instance.contentOfCollectionsOfCats[0].nameOfCat;
        currentCatDescription.text = CollectionOfCats.instance.contentOfCollectionsOfCats[0].descriptionOfCat;
        currentCatVisual.sprite = CollectionOfCats.instance.contentOfCollectionsOfCats[0].visual;
    }

    public void PrintCatIU(int indexOfButton)
    {
        currentCatName.text = CollectionOfCats.instance.contentOfCollectionsOfCats[indexOfButton].nameOfCat;
        currentCatDescription.text = CollectionOfCats.instance.contentOfCollectionsOfCats[indexOfButton].descriptionOfCat;
        currentCatVisual.sprite = CollectionOfCats.instance.contentOfCollectionsOfCats[indexOfButton].visual;
    }
    public void AddCat(CatData newCat)
    {
        if (collectionOfCats.IsFull() == true)
        {
            Debug.Log("Collection full, can't take : " + newCat.name);
            return;
        }
        CollectionOfCats.instance.contentOfCollectionsOfCats.Add(newCat);
        collectionOfCats.RefreshCollectionOfCats();
    }


    void Update()
    {
        if (checker == true)
        {
            AddCat(newCatAdd.nameOfCat);
            checker = false;
            PrintNewCatUI(newCatAdd.nameOfCat);
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
