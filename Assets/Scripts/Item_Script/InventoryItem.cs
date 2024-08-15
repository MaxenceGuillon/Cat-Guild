using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;

//Loading_Scene ( in GameObject : InventoryItem ) 

public class InventoryItem : MonoBehaviour
{
    public List<ItemData> collectionItem = new List<ItemData>(); // Player's items collection
    public List<ItemData> listEmptyItem = new List<ItemData>(); // Empty list to print empty item in market
    public List<ItemData> marketItem = new List<ItemData>(); // Market's items

    [SerializeField]
    private Transform collectionOfItemSlotParent;
    [SerializeField]
    private Transform collectionOfItemInCollectionSlotParent;
    [SerializeField]
    private Transform marketItemSlotParent;

    const int collectionItemSize = 20; 
    const int marketItemSize = 12;

    public ModificationOfInventory modificationOfInventory;

    public static InventoryItem instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de InventoryItem dans la scène");
            return;
        }
        instance = this;
    }

    private void Start()
    {
        RefreshCollectionOfItem();
        RefreshMarketItem();
    }

    // Update of UI in player's item collection in Market
    public void RefreshCollectionOfItem()
    {
        for (int i = 0; i < collectionItemSize; i++)
        {
            if (i < collectionItem.Count)
            {
                collectionOfItemSlotParent.GetChild(i).GetChild(0).GetComponent<Text>().text = collectionItem[i].nameItem;
                collectionOfItemSlotParent.GetChild(i).GetChild(1).GetComponent<Image>().sprite = collectionItem[i].visualItem;
            }
            else
            {
                collectionOfItemSlotParent.GetChild(i).GetChild(0).GetComponent<Text>().text = listEmptyItem[0].nameItem;
                collectionOfItemSlotParent.GetChild(i).GetChild(1).GetComponent<Image>().sprite = listEmptyItem[0].visualItem;
            }
        }
    }

    // Update of UI in player's item collection in player's collection
    public void RefreshCollectionOfItemInCollection()
    {

        for (int i = 0; i < collectionItemSize; i++)
        {
            if (i < collectionItem.Count)
            {
                collectionOfItemInCollectionSlotParent.GetChild(i).GetChild(0).GetComponent<Text>().text = collectionItem[i].nameItem;
                collectionOfItemInCollectionSlotParent.GetChild(i).GetChild(1).GetComponent<Image>().sprite = collectionItem[i].visualItem;
            }
            else
            {

                collectionOfItemInCollectionSlotParent.GetChild(i).GetChild(0).GetComponent<Text>().text = listEmptyItem[0].nameItem;
                collectionOfItemInCollectionSlotParent.GetChild(i).GetChild(1).GetComponent<Image>().sprite = listEmptyItem[0].visualItem;
            }
        }
    }

    // Update of UI in market
    public void RefreshMarketItem()
    {

        for (int i = 0; i < marketItemSize; i++)
        {
            if (i < marketItem.Count)
            {
                marketItemSlotParent.GetChild(i).GetChild(0).GetComponent<Text>().text = marketItem[i].nameItem;
                marketItemSlotParent.GetChild(i).GetChild(1).GetComponent<Image>().sprite = marketItem[i].visualItem;
            }
            else
            {
                marketItemSlotParent.GetChild(i).GetChild(0).GetComponent<Text>().text = listEmptyItem[0].nameItem;
                marketItemSlotParent.GetChild(i).GetChild(1).GetComponent<Image>().sprite = listEmptyItem[0].visualItem;
            }
        }
    }

    public bool InventoryIsFull()
    {
        return collectionItemSize == collectionItem.Count;
    }

    public bool MarketIsFull()
    {
        return collectionItemSize == collectionItem.Count;
    }
}
