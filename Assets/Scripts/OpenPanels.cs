using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenPanels : MonoBehaviour
{

    public GameObject panelCollection;
    public GameObject panelRoulette;
    public GameObject panelMarket;
    public GameObject textDialogueComeBackLater;
    public GameObject ComeBackLaterButton;
    public GameObject CollectionItems;
    public GameObject CollectionCats;

    public static OpenPanels instance;

    public Animator buyAnItemUI;
    public Animator sendAnItemUI;

    public int indexSlotCat;
    public int indexSlotItem;
    public int indexSlotItemMarket;

    public int indexTempo;

    public ModificationOfCollectionOfCats modificationOfCollectionOfCats;
    public ModificationOfInventory  modificationOfInventory;

    public InventoryItem inventoryItem;
    public CollectionOfCats collectionOfCats;

    public PanelData panelDataIdCat;
    public PanelData panelDataIdItem;
    public PanelData panelDataIdItemMarket;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance d'openPanels dans la scène");
            return;
        }
        instance = this;
    }

    public void OpenCollectionPanel()
    {
        panelCollection.SetActive(true);
        modificationOfCollectionOfCats.PrintFirstCatIU();
        inventoryItem.RefreshCollectionOfItemInCollection();
        CollectionItems.SetActive(false);
        CollectionCats.SetActive(true);
    }

   
    public void CloseCollectionPanel()
    {
        panelCollection.SetActive(false);
    }

    public void ClicOnCatButton(int indexSlotCat)
    {
        if (indexSlotCat > CollectionOfCats.instance.contentOfCollectionsOfCats.Count -1)
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
    public void OpenRoulettePanel()
    {
        panelRoulette.SetActive(true);
    }

    public void CloseRoulettePanel()
    {
        panelRoulette.SetActive(false);
    }

    public void OpenMarketPanel()
    {
        modificationOfInventory.PrintItemIU(0);
        panelMarket.SetActive(true);
    }

    public void CloseMarketPanel()
    {
        panelMarket.SetActive(false);
    }

    public void OpenDialogueComeBackLaterPanel()
    {
        textDialogueComeBackLater.SetActive(true);
    }

    public void ComeBackToHub(string mainPage)
    {
        SceneManager.LoadScene(mainPage);
    }

    public void ClicCollectionItemButton(int indexSlotItem)
    {
        inventoryItem.RefreshCollectionOfItemInCollection();
        CollectionItems.SetActive(true);
        CollectionCats.SetActive(false);
    }

    public void ClicCollectionCatsButton()
    {
        collectionOfCats.RefreshCollectionOfCats();
        CollectionItems.SetActive(false);
        CollectionCats.SetActive(true);
    }

    public void CloseAllPanel()
    {
        if (panelCollection == true) CloseCollectionPanel();
        if (panelMarket == true) CloseMarketPanel();
        if (panelRoulette == true) CloseRoulettePanel();
        if (panelMarket == true) CloseMarketPanel();

    }
}
