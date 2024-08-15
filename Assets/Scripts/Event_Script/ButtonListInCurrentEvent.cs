using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class ButtonListInCurrentEvent : MonoBehaviour

{

    public List<int> buttonListInCurrentEvent = new List<int>();

    public PrintCurrentEvent printCurrentEvent;
    

    const int buttonlistSize = 6;

    public int eventTempo;
    public string tournamentScene = "Tournament_Scene";

    [SerializeField]
    private Transform listOfButtonParent;

    public static ButtonListInCurrentEvent instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de ButtonListInCurrentEvent dans la scène");
            return;
        }
        instance = this;

        eventTempo = GameManager.instance.idCurrentEvent;

        RefreshButtonListInCurrentEvent(eventTempo);
    }


    public void RefreshButtonListInCurrentEvent(int j)
    {
        buttonListInCurrentEvent[0] = printCurrentEvent.currentEventFirstButtonId;
        buttonListInCurrentEvent[1] = printCurrentEvent.currentEventSegondButtonId;
        buttonListInCurrentEvent[2] = printCurrentEvent.currentEventThirdButtonId;
        buttonListInCurrentEvent[3] = printCurrentEvent.currentEventFourthButtonId;
        buttonListInCurrentEvent[4] = printCurrentEvent.currentEventFifthButtonId;
        buttonListInCurrentEvent[5] = printCurrentEvent.currentEventSixthButtonId;


        for (int i = 0; i < buttonListInCurrentEvent.Count; i++)
        {

            if(buttonListInCurrentEvent[i] == 0) listOfButtonParent.GetChild(i).gameObject.SetActive(false);

            if (buttonListInCurrentEvent[i] == 1)
            {
                listOfButtonParent.GetChild(i).gameObject.SetActive(true);
                listOfButtonParent.GetChild(i).GetChild(0).GetComponent<Text>().text = "Market";
                listOfButtonParent.GetChild(i).GetChild(1).GetChild(0).GetComponent<Text>().text = "+" + printCurrentEvent.marketPoint.ToString();
            }

            if (buttonListInCurrentEvent[i] == 2)
            {
                listOfButtonParent.GetChild(i).gameObject.SetActive(true);
                listOfButtonParent.GetChild(i).GetChild(0).GetComponent<Text>().text = "Tournament";
                listOfButtonParent.GetChild(i).GetChild(1).GetChild(0).GetComponent<Text>().text = "+" + printCurrentEvent.tournamentPoint.ToString();
            }

            if (buttonListInCurrentEvent[i] == 3)
            {
                listOfButtonParent.GetChild(i).gameObject.SetActive(true);
                listOfButtonParent.GetChild(i).GetChild(0).GetComponent<Text>().text = "Roulette";
                listOfButtonParent.GetChild(i).GetChild(1).GetChild(0).GetComponent<Text>().text = "+" + printCurrentEvent.roulettePoint.ToString();
            }

            if (buttonListInCurrentEvent[i] == 4)
            {
                listOfButtonParent.GetChild(i).gameObject.SetActive(true);
                listOfButtonParent.GetChild(i).GetChild(0).GetComponent<Text>().text = "Add Cat";
                listOfButtonParent.GetChild(i).GetChild(1).GetChild(0).GetComponent<Text>().text = "+" + printCurrentEvent.addCat.ToString();
            }

            if (buttonListInCurrentEvent[i] == 5)
            {
                listOfButtonParent.GetChild(i).gameObject.SetActive(true);
                listOfButtonParent.GetChild(i).GetChild(0).GetComponent<Text>().text = "Activities";
                listOfButtonParent.GetChild(i).GetChild(1).GetChild(0).GetComponent<Text>().text = "+" + printCurrentEvent.activitiesPoint.ToString();
            }

            if (buttonListInCurrentEvent[i] == 6)
            {
                listOfButtonParent.GetChild(i).gameObject.SetActive(true);
                listOfButtonParent.GetChild(i).GetChild(0).GetComponent<Text>().text = "Quests";
                listOfButtonParent.GetChild(i).GetChild(1).GetChild(0).GetComponent<Text>().text = "+" + printCurrentEvent.questPoint.ToString();
            }
        }
    }
    public void ClicOnButtonInEventPanel(int k)
    {
            if (listOfButtonParent.GetChild(k).GetChild(0).GetComponent<Text>().text == "Market")
            {
                OpenPanels.instance.CloseAllPanel();
                OpenPanels.instance.OpenMarketPanel();
                return;
            }

            if (listOfButtonParent.GetChild(k).GetChild(0).GetComponent<Text>().text == "Tournament")
            {
                OpenPanels.instance.CloseAllPanel();
                SceneManager.LoadScene(tournamentScene);
                return;
            }

            if (listOfButtonParent.GetChild(k).GetChild(0).GetComponent<Text>().text == "Roulette")
            {
                OpenPanels.instance.CloseAllPanel();
                OpenPanels.instance.OpenRoulettePanel();
                return;
            }

            if (listOfButtonParent.GetChild(k).GetChild(0).GetComponent<Text>().text == "Add Cat")
            {
                OpenPanels.instance.CloseAllPanel();
                OpenPanels.instance.OpenCollectionPanel();
                return;
            }

            if (listOfButtonParent.GetChild(k).GetChild(0).GetComponent<Text>().text == "Activities")
            {
                return;
            }

            if (listOfButtonParent.GetChild(k).GetChild(0).GetComponent<Text>().text == "Quests")
            {
                OpenPanels.instance.CloseAllPanel();
                OpenPanels.instance.OpenQuestPanel();
                return;
            }

    }
}
