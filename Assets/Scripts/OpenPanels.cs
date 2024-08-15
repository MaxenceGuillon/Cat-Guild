using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Loading_Scene ( in GameObject : CanvasPanelUI / PanelManager )

public class OpenPanels : MonoBehaviour
{
    // All Panels of the game
    public GameObject panelCollection;
    public GameObject panelRoulette;
    public GameObject panelEvent;
    public GameObject panelEventReward;
    public GameObject panelMarket;
    public GameObject panelQuest;
    public GameObject textDialogueComeBackLater;
    public GameObject comeBackLaterButton;
    public GameObject collectionItems;
    public GameObject collectionCats;

    // Market Animations
    public Animator buyAnItemUI;
    public Animator sendAnItemUI;

    // Cat or item index to print good UI in differents collections in the game
    public int indexSlotCat;
    public int indexSlotItem;
    public int indexSlotItemMarket;
    public int indexSlotEventButton;

    public int indexTempo;

    public ModificationOfCollectionOfCats modificationOfCollectionOfCats;
    public ModificationOfInventory modificationOfInventory;
    public PrintCurrentEvent printCurrentEvent;
    public InventoryItem inventoryItem;
    public CollectionOfCats collectionOfCats;


    public static OpenPanels instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance d'openPanels dans la scène");
            return;
        }
        instance = this;

        // Print event tittle on event button in Mage_Page scene
        if (GameManager.instance.eventNow == true)
        {
            printCurrentEvent.PrintCurrentEventData(printCurrentEvent.contentEventList[GameManager.instance.idCurrentEvent]);
            GameManager.instance.eventTittle = printCurrentEvent.currentEventName.text;
            return;
        }
    }

    private void Update()
    {
        // Event rewards Unlock

        if ((DataPlayer.instance.currentEventPoint >= 25) && (printCurrentEvent.unlockFirstReward == false))
        {
            printCurrentEvent.lockFirstReward.SetActive(false);
            printCurrentEvent.unlockFirstReward = true;
            printCurrentEvent.PrintPanelNewReward(printCurrentEvent.contentEventList[GameManager.instance.idCurrentEvent], 0);
        }

        if ((DataPlayer.instance.currentEventPoint >= 50) && (printCurrentEvent.unlockSegondReward == false))
        {
            printCurrentEvent.lockSegondReward.SetActive(false);
            printCurrentEvent.unlockSegondReward = true;
            printCurrentEvent.PrintPanelNewReward(printCurrentEvent.contentEventList[GameManager.instance.idCurrentEvent], 1);
        }

        if ((DataPlayer.instance.currentEventPoint >= 75) && (printCurrentEvent.unlockThirdReward == false))
        {
            printCurrentEvent.lockThirdReward.SetActive(false);
            printCurrentEvent.unlockThirdReward = true;
            printCurrentEvent.PrintPanelNewReward(printCurrentEvent.contentEventList[GameManager.instance.idCurrentEvent], 2);
        }

        if ((DataPlayer.instance.currentEventPoint == 100) && (printCurrentEvent.unlockLastReward == false))
        {
            printCurrentEvent.lockLastReward.SetActive(false);
            printCurrentEvent.unlockLastReward = true;
            printCurrentEvent.PrintPanelNewReward(printCurrentEvent.contentEventList[GameManager.instance.idCurrentEvent], 3);
        }
    }

    // Cat collection panels methods
    public void OpenCollectionPanel()
    {
        panelCollection.SetActive(true);
        modificationOfCollectionOfCats.PrintFirstCatIU();
        inventoryItem.RefreshCollectionOfItemInCollection();
        collectionItems.SetActive(false);
        collectionCats.SetActive(true);
    }

    public void CloseCollectionPanel()
    {
        panelCollection.SetActive(false);
    }

    public void ClicOnCatButton(int indexSlotCat)
    {
        if (indexSlotCat > CollectionOfCats.instance.catsCollectionContent.Count -1)
        {
            return;
        }
        modificationOfCollectionOfCats.PrintCatIU(indexSlotCat);
    }

    public void ClicOnItemButton(int indexSlotItem)
    {
        if (indexSlotItem >= InventoryItem.instance.collectionItem.Count)
        {
            
            return;
        }
        sendAnItemUI.SetBool("IsActivate", true);
        buyAnItemUI.SetBool("IsON", false);
        modificationOfInventory.PrintItemIU(indexSlotItem);
        indexTempo = indexSlotItem;
    }

    public void ClicOnItemCollectionButton(int indexSlotItem)
    {
        if (indexSlotItem >= InventoryItem.instance.collectionItem.Count)
        {
            return;
        }
    }

    public void ClicCollectionItemButton(int indexSlotItem)
    {
        inventoryItem.RefreshCollectionOfItemInCollection();
        collectionItems.SetActive(true);
        collectionCats.SetActive(false);
    }

    public void ClicCollectionCatsButton()
    {
        collectionOfCats.RefreshCollectionOfCats();
        collectionItems.SetActive(false);
        collectionCats.SetActive(true);
    }

    // Market panels methods
    public void OpenMarketPanel()
    {
        modificationOfInventory.PrintItemIU(0);
        panelMarket.SetActive(true);
    }

    public void CloseMarketPanel()
    {
        panelMarket.SetActive(false);
    }

    public void ClicOnMarketItemButton(int indexSlotItemMarket)
    {
        if (indexSlotItemMarket >= InventoryItem.instance.marketItem.Count)
        {
            return;
        }
        sendAnItemUI.SetBool("IsActivate", false);
        buyAnItemUI.SetBool("IsON",true);
        modificationOfInventory.PrintItemMarketIU(indexSlotItemMarket);
        indexTempo = indexSlotItemMarket;
    }

    public void ClicOnBuyingMarketButton()
    {
            modificationOfInventory.BuyAnItem(indexTempo);
    }

    public void ClicOnSendingMarketButton()
    {
            modificationOfInventory.SendAnItem(indexTempo);
    }

    // Roulette panels methods
    public void OpenRoulettePanel()
    {
        panelRoulette.SetActive(true);
    }

    public void CloseRoulettePanel()
    {
        panelRoulette.SetActive(false);
    }

    // Event panels methods
    public void OpenEventPanel()
    {
        CloseAllPanel();
        panelEvent.SetActive(true);
    }

    public void CloseEventPanel()
    {
        panelEvent.SetActive(false);
    }

    public void OpenEventRewardPanel()
    {
        panelEventReward.SetActive(true);
    }

    public void CloseEventRewardPanel()
    {
        panelEventReward.SetActive(false);
    }

    // Quest panels methods
    public void OpenQuestPanel()
    {
        panelQuest.SetActive(true);
    }

    public void CloseQuestPanel()
    {
        panelQuest.SetActive(false);
    }

    // If player go in a zone whitout adventure
    public void OpenDialogueComeBackLaterPanel()
    {
        textDialogueComeBackLater.SetActive(true);
    }

    // Return in Mage_Page state without open panel
    public void CloseAllPanel()
    {
        if (panelCollection == true) CloseCollectionPanel();
        if (panelMarket == true) CloseMarketPanel();
        if (panelRoulette == true) CloseRoulettePanel();
        if (panelMarket == true) CloseMarketPanel();
        if (panelQuest == true) CloseQuestPanel();
        if (panelEvent == true) CloseEventPanel();
        if (panelEventReward == true) CloseEventRewardPanel();
    }
}
