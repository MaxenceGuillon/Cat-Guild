using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Loading_Scene ( in GameObjects : CanvasItemsCats / MarketItemCanvas || CanvasItemsCats / MarketItemCanvas )

public class ModificationOfInventory : MonoBehaviour
{
    // Print UI informations
    public Text currentItemName;
    public Image currentItemVisual;
    public Text currentItemPrice;

    public InventoryItem inventoryItem;
    public OpenPanels openPanels;
    public PrintCurrentEvent printCurrentEvent;
    public AnimationPanelEventPointWin animationPanelEventPointWin;

    public void PrintItemIU(int indexOfItemButton)
    {
        // Print empty item UI 
        if(indexOfItemButton >= InventoryItem.instance.collectionItem.Count)
        {
            currentItemName.text = InventoryItem.instance.listEmptyItem[0].nameItem;
            currentItemVisual.sprite = InventoryItem.instance.listEmptyItem[0].visualItem;
            currentItemPrice.text = InventoryItem.instance.listEmptyItem[0].priceUI;
        }
        // Print item in martek in player's collection side UI
        else
        {
            InventoryItem.instance.collectionItem[indexOfItemButton].inMarket = false;
            InventoryItem.instance.collectionItem[indexOfItemButton].priceUI = InventoryItem.instance.collectionItem[indexOfItemButton].sendingPrice.ToString();
            currentItemName.text = InventoryItem.instance.collectionItem[indexOfItemButton].nameItem;
            currentItemVisual.sprite = InventoryItem.instance.collectionItem[indexOfItemButton].visualItem;
            currentItemPrice.text = InventoryItem.instance.collectionItem[indexOfItemButton].priceUI;
        }
    }

    // Print item in martek in market side UI
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

    // Print empty item UI in case player byuing item in market
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

        // Item add in player's collection
        InventoryItem.instance.collectionItem.Add(newItem);
        inventoryItem.RefreshCollectionOfItem();

        // If there is an event adding event points in event page && play animation openpanelEventPointsWin
        if (GameManager.instance.eventNow == true) DataPlayer.instance.EventPointWin(printCurrentEvent.marketPoint);
        if ((GameManager.instance.eventNow == true) && (animationPanelEventPointWin.lockToMainAnim == false)) printCurrentEvent.PrintPanelEventPointsWin(printCurrentEvent.marketPoint);
    }

    // When player sends an item in market
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

    // When player buys an item in market
    public void BuyAnItem (int indexOfMarketItemButton)
    {
        if (inventoryItem.MarketIsFull() == true) return;
        if (inventoryItem.marketItem.Count == 0) return;
        if (inventoryItem.InventoryIsFull() == true) return;

        // Case : Player have money to buy a select item
        if(DataPlayer.instance.coinsCount >= InventoryItem.instance.marketItem[indexOfMarketItemButton].buyingPrice)
        {
            DataPlayer.instance.coinsCount = DataPlayer.instance.coinsCount - InventoryItem.instance.marketItem[indexOfMarketItemButton].buyingPrice;
            AddItem(InventoryItem.instance.marketItem[indexOfMarketItemButton]);
            inventoryItem.marketItem.Remove(InventoryItem.instance.marketItem[indexOfMarketItemButton]);
            inventoryItem.RefreshCollectionOfItem();
            inventoryItem.RefreshMarketItem();

            // Print empty item if there is no item in market after buying
            if (inventoryItem.marketItem.Count == 0)
            {
                PrintEmptyItem();
            }

            // Print next item after buying UI
            else
            {
                PrintItemMarketIU(indexOfMarketItemButton);
            }
        }

        // Case : Player have no money to buy a select item
        else
        {
            Debug.Log ("Pas assez de thunes");
        }
    }

    // Player send 
    public void SendAnItem(int indexItemButton)
    {
        if (inventoryItem.MarketIsFull() == true) return;
        if (inventoryItem.collectionItem.Count == 0) return;
        if (inventoryItem.InventoryIsFull() == true) return;

        // Add money in Dataplayer && Add send item in market collection
        DataPlayer.instance.coinsCount = DataPlayer.instance.coinsCount + InventoryItem.instance.collectionItem[indexItemButton].sendingPrice;
        AddItemInMarket(InventoryItem.instance.collectionItem[indexItemButton]);
        inventoryItem.collectionItem.Remove(InventoryItem.instance.collectionItem[indexItemButton]);
        inventoryItem.RefreshCollectionOfItem();
        inventoryItem.RefreshMarketItem();

        if (inventoryItem.collectionItem.Count == 0) PrintEmptyItem();
        else PrintItemIU(indexItemButton);
    }
}
