using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPanels : MonoBehaviour
{

    public GameObject settingsWindow;
    public GameObject panelRoulette;

    public static OpenPanels instance;

    public int indexSlotCat;

    public ModificationOfCollectionOfCats modificationOfCollectionOfCats;

    public PanelData panelData;

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
        settingsWindow.SetActive(true);
        modificationOfCollectionOfCats.PrintFirstCatIU();
    }

    public void CloseCollectionPanel()
    {
        settingsWindow.SetActive(false);
    }

    public void ClicOnCatButton(int indexSlotCat)
    {
        if (indexSlotCat > CollectionOfCats.instance.contentOfCollectionsOfCats.Count -1)
        {
            return;
        }
        modificationOfCollectionOfCats.PrintCatIU(indexSlotCat);
    }

    public void OpenRoulettePanel()
    {
        panelRoulette.SetActive(true);
    }

    public void CloseRoulettePanel()
    {
        panelRoulette.SetActive(false);
    }
}
