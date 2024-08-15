using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using UnityEngine.UI;

// Loading_Scene ( in GameObject : CollectionOfCats ) 

public class CollectionOfCats : MonoBehaviour
{
    // Player's CatCollection
    public List<CatInstance> catsCollectionContent = new List<CatInstance>();

    const int collectionSize = 24;

    public ModificationOfCollectionOfCats modificationOfCollectionOfCats;

    [SerializeField]
    private Transform catsCollectionSlotParent;

    public static CollectionOfCats instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de CollectionOfCats dans la scène");
            return;
        }
        instance = this;
    }

    private void Start()
    {
        RefreshCollectionOfCats();
    }

    // Print update of player's cats collection
    public void RefreshCollectionOfCats()
    {
        for (int i = 0; i < catsCollectionContent.Count; i++)
        {
            catsCollectionSlotParent.GetChild(i).GetChild(0).GetComponent<Text>().text = catsCollectionContent[i].cat.nameOfCat;
            catsCollectionSlotParent.GetChild(i).GetChild(1).GetComponent<Image>().sprite = catsCollectionContent[i].cat.visual;
        }
    }

    public bool IsFull()
    {
        return collectionSize == catsCollectionContent.Count;
    }
}