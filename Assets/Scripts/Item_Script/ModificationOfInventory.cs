using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ModificationOfInventory : MonoBehaviour
{


    public Text currentItemName;
    public Image currentItemVisual;
    public Text currentItemPrice;

    public InventoryItem inventoryItem;
    public OpenPanels openPanels;

    public DataPlayer dataPlayer;

    public void PrintItemIU(int indexOfItemButton)
    {
        if(indexOfItemButton >= InventoryItem.instance.collectionItem.Count)
        {
            currentItemName.text = InventoryItem.instance.listEmptyItem[0].nameItem;
            currentItemVisual.sprite = InventoryItem.instance.listEmptyItem[0].visualItem;
            currentItemPrice.text = InventoryItem.instance.listEmptyItem[0].priceUI;
        }
        else
        {
            InventoryItem.instance.collectionItem[indexOfItemButton].inMarket = false;
            InventoryItem.instance.collectionItem[indexOfItemButton].priceUI = InventoryItem.instance.collectionItem[indexOfItemButton].sendingPrice.ToString();
            currentItemName.text = InventoryItem.instance.collectionItem[indexOfItemButton].nameItem;
            currentItemVisual.sprite = InventoryItem.instance.collectionItem[indexOfItemButton].visualItem;
            currentItemPrice.text = InventoryItem.instance.collectionItem[indexOfItemButton].priceUI;
        }
    }

    public void PrintItemMarketIU(int indexOfItemButton)
    {
        if (indexOfItemButton >= InventoryItem.instance.marketItem.Count)
        {
            currentItemName.text = InventoryItem.instance.listEmptyItem[0].nameItem;
            currentItemVisual.sprite = InventoryItem.instance.listEmptyItem[0].visualItem;
            currentItemPrice.text = InventoryItem.instance.listEmptyItem[0].priceUI;
        }
        else
        {
            InventoryItem.instance.marketItem[indexOfItemButton].inMarket = true;
            InventoryItem.instance.marketItem[indexOfItemButton].priceUI = InventoryItem.instance.marketItem[indexOfItemButton].buyingPrice.ToString();
            currentItemName.text = InventoryItem.instance.marketItem[indexOfItemButton].nameItem;
            currentItemVisual.sprite = InventoryItem.instance.marketItem[indexOfItemButton].visualItem;
            currentItemPrice.text = InventoryItem.instance.marketItem[indexOfItemButton].priceUI;
        }
    }

    public void PrintEmptyItem()
    {
        currentItemName.text = InventoryItem.instance.listEmptyItem[0].nameItem;
        currentItemVisual.sprite = InventoryItem.instance.listEmptyItem[0].visualItem;
        currentItemPrice.text = InventoryItem.instance.listEmptyItem[0].priceUI;
    }
    public void AddItem(ItemData newItem)
    {
        if (inventoryItem.InventoryIsFull() == true)
        {
            Debug.Log("Collection full, can't take : " + newItem.nameItem);
            return;
        }
        InventoryItem.instance.collectionItem.Add(newItem);
        inventoryItem.RefreshCollectionOfItem();
    }
    public void AddItemInMarket(ItemData newItem)
    {
        if (inventoryItem.MarketIsFull() == true)
        {
            Debug.Log("Market full, can't take : " + newItem.nameItem);
            return;
        }
        InventoryItem.instance.marketItem.Add(newItem);
        inventoryItem.RefreshMarketItem();
    }
    public void BuyAnItem (int indexOfMarketItemButton)
    {
        if (inventoryItem.MarketIsFull() == true) return;
        if (inventoryItem.marketItem.Count == 0) return;
        if (inventoryItem.InventoryIsFull() == true) return;

        if(dataPlayer.coinsCount >= InventoryItem.instance.marketItem[indexOfMarketItemButton].buyingPrice)
        {
            dataPlayer.coinsCount = dataPlayer.coinsCount - InventoryItem.instance.marketItem[indexOfMarketItemButton].buyingPrice;
            AddItem(InventoryItem.instance.marketItem[indexOfMarketItemButton]);
            inventoryItem.marketItem.Remove(InventoryItem.instance.marketItem[indexOfMarketItemButton]);
            inventoryItem.RefreshCollectionOfItem();
            inventoryItem.RefreshMarketItem();
            if (inventoryItem.marketItem.Count == 0)
            {
                PrintEmptyItem();
            }
            else
            {
                PrintItemMarketIU(indexOfMarketItemButton);
            }
        }
        else
        {
            Debug.Log("Pas assez de thunes");
        }
    }

    public void SendAnItem(int indexItemButton)
    {
        if (inventoryItem.MarketIsFull() == true) return;
        if (inventoryItem.collectionItem.Count == 0) return;
        if (inventoryItem.InventoryIsFull() == true) return;

        dataPlayer.coinsCount = dataPlayer.coinsCount + InventoryItem.instance.collectionItem[indexItemButton].sendingPrice;
        AddItemInMarket(InventoryItem.instance.collectionItem[indexItemButton]);
        inventoryItem.collectionItem.Remove(InventoryItem.instance.collectionItem[indexItemButton]);
        inventoryItem.RefreshCollectionOfItem();
        inventoryItem.RefreshMarketItem();
        if (inventoryItem.collectionItem.Count == 0)
        {
            PrintEmptyItem();
        }
        else
        {
            PrintItemIU(indexItemButton);
        }
    }
}
