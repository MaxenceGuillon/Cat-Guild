using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using UnityEngine.UI;



public class CollectionOfCats : MonoBehaviour
{

    public List<CatInstance> contentOfCollectionsOfCats = new List<CatInstance>();

    public ModificationOfCollectionOfCats modificationOfCollectionOfCats;

    const int collectionSize = 24;

    [SerializeField]
    private Transform collectionOfCatSlotParent;

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

    public void RefreshCollectionOfCats()
    {

        for (int i = 0; i < contentOfCollectionsOfCats.Count; i++)
        {
            collectionOfCatSlotParent.GetChild(i).GetChild(0).GetComponent<Text>().text = contentOfCollectionsOfCats[i].cat.nameOfCat;
            collectionOfCatSlotParent.GetChild(i).GetChild(1).GetComponent<Image>().sprite = contentOfCollectionsOfCats[i].cat.visual;
        }
    }
    public bool IsFull()
    {
        return collectionSize == contentOfCollectionsOfCats.Count;
    }
}