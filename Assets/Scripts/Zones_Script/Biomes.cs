using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

// Loading_Scene ( in GameObject : BackgroundAdventureCanvas / BackgroundZone )

public class Biomes : MonoBehaviour
{
    public List<DataZone> zonesList = new List<DataZone>(); // List of differents zones in game

    public int zoneIDChoose;
    public DataZone currentZone;

    // variables to animation "open panel of new zone"
    public Animator openPanelTittleOfZone;
    public GameObject tittleOfZone;
    public Text tittleOfaZoneUIText;

    // UI print when player select zone
    public Image zonePrint;
    public GameObject backgroundPrint;


    public static Biomes instance;

    private void Awake()
    {
        if (instance != null)
            {
                Debug.LogWarning("Il y a plus d'une instance Biomes dans la scène");
                return;
            }
        instance = this;

        GameManager.instance.numberOfZone = zonesList.Count;

        // Reset all zones of the game at the begginning of game
        for (int i = 0; i < zonesList.Count; i++)
        {
            zonesList[i].isFirstTime = true;
        }
    }

    public void printZone()
    {
        zoneIDChoose = GameManager.instance.iDZoneChoose;

        for (int i = 0; i < GameManager.instance.numberOfZone; i++)
        {
            if (i == zoneIDChoose)
            {
                currentZone = zonesList[i];
                zonePrint.sprite = currentZone.zoneVisual;
            }
        }
    }

    public void Update()
    {
        if (GameManager.instance.inAdventureScene) printZone();
        if ((currentZone.isFirstTime == true) && (GameManager.instance.inAdventureScene == true))
        {
            tittleOfaZoneUIText.text = currentZone.zoneName.ToString();
            tittleOfZone.SetActive(true);
            StartCoroutine(WaitForAnimationTittleOfZone(2.0f));
            currentZone.isFirstTime = false;
        }
    }

    IEnumerator WaitForAnimationTittleOfZone(float f)
    {
        openPanelTittleOfZone.SetBool("tittleOfZoneIsOpen", true);
        yield return new WaitForSeconds(f);
        openPanelTittleOfZone.SetBool("tittleOfZoneIsOpen", false);
    }
}
