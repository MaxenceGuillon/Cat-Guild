using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PrintCurrentEvent : MonoBehaviour
{
    public List<EventData> contentEventList = new List<EventData>();

    public int idCurrentEvent;

    public Text currentEventName;
    public Text currentEventDescription;
    public Image currentEventVisual;

    public int maxEventPoint;

    public Text playerEventPointText;

    
    public Image currentFirstReward;
    public Image currentSegondReward;
    public Image currentThirdReward;
    public Image currentLastReward;

    public Image RewardInPanelUI;

    public bool unlockFirstReward = false;
    public bool unlockSegondReward =  false;
    public bool unlockThirdReward = false;
    public bool unlockLastReward = false;

    public GameObject lockFirstReward;
    public GameObject lockSegondReward;
    public GameObject lockThirdReward;
    public GameObject lockLastReward;

    public GameObject CheckFirstReward;
    public GameObject CheckSegondReward;
    public GameObject CheckThirdReward;
    public GameObject CheckLastReward;

    public Image currentMainRewardVisual;
    public Text currentMainRewardName;


    public int currentEventFirstButtonId;
    public int currentEventSegondButtonId;
    public int currentEventThirdButtonId;
    public int currentEventFourthButtonId;
    public int currentEventFifthButtonId;
    public int currentEventSixthButtonId;

    public int marketPoint;
    public int tournamentPoint;
    public int roulettePoint;
    public int addCat;
    public int activitiesPoint;
    public int questPoint;



    public Text currentEventTittleInPanel;
    public Text eventPointsWinText;
    public GameObject eventPointsWin;
    public GameObject eventUIEndSentenceText;
    public GameObject eventUINewRewardText;
    public GameObject eventUINewRewardPicture;

    public Image eventUIPanel;
    public Image refColorEventPointWin;
    public Image refColorEventNewReward;

    public Image rewardTakeVisualInPanel;
    public Text RewardTakeNameInPanel;


    public static PrintCurrentEvent instance;

    public AnimationPanelEventPointWin animationPanelEventPointWin;
    public SliderEvent sliderEvent;
    public OpenPanels openPanels;
    public ModificationOfInventory modificationOfInventory;
    public ModificationOfCollectionOfCats modificationOfCollectionOfCats;

    private void Awake()
    {
        idCurrentEvent = GameManager.instance.idCurrentEvent;
    }

        public void PrintCurrentEventData(EventData eventData)
    {
        currentEventName.text = eventData.eventName;
        currentEventDescription.text = eventData.descriptionOfEvent;
        currentEventVisual.sprite = eventData.eventConcept;

        maxEventPoint = eventData.maxEventPoint;

        playerEventPointText.text = DataPlayer.instance.currentEventPoint.ToString();

        currentFirstReward.sprite = eventData.firstReward.visualItem;
        currentSegondReward.sprite = eventData.segondReward.visualItem;
        currentThirdReward.sprite = eventData.thirdReward.visualItem;
        currentLastReward.sprite = eventData.lastReward.visual;

        currentMainRewardVisual.sprite = eventData.lastReward.visual;
        currentMainRewardName.text = eventData.lastReward.nameOfCat;

        currentEventFirstButtonId = eventData.eventFirstButtonId;
        currentEventSegondButtonId = eventData.eventSegondButtonId;
        currentEventThirdButtonId = eventData.eventThirdButtonId;
        currentEventFourthButtonId = eventData.eventFourthButtonId;
        currentEventFifthButtonId = eventData.eventFifthButtonId;
        currentEventSixthButtonId = eventData.eventSixthButtonId;

        marketPoint = eventData.marketPoint;
        tournamentPoint = eventData.tournamentPoint;
        roulettePoint = eventData.roulettePoint;
        addCat = eventData.addCat;
        activitiesPoint = eventData.activitiesPoint;
        questPoint = eventData.questPoint;

        currentEventTittleInPanel.text = eventData.eventName;

    }

   

    public void PrintPanelEventPointsWin(int i)
    {
        if (DataPlayer.instance.currentEventPoint == maxEventPoint) return;

        eventPointsWinText.text = "+" + i.ToString() + " ep";

        eventUIPanel.color = refColorEventPointWin.color;
        eventPointsWin.SetActive(true);
        eventUIEndSentenceText.SetActive(true);
        eventUINewRewardText.SetActive(false);
        eventUINewRewardPicture.SetActive(false);
        animationPanelEventPointWin.launchPointWinPanelAnimBool = true;
    }

    public void PrintPanelNewReward(EventData eventData,int i)
    {
        StopAllCoroutines();

        if(i  == 0)
        {
            RewardInPanelUI.sprite = eventData.firstReward.visualItem;
            eventUIPanel.color = refColorEventNewReward.color;
            eventPointsWin.SetActive(false);
            eventUIEndSentenceText.SetActive(false);
            eventUINewRewardText.SetActive(true);
            eventUINewRewardPicture.SetActive(true);
            animationPanelEventPointWin.lockToMainAnim = true;
            animationPanelEventPointWin.launchNewRewardPanelAnimBool = true;
        }

        if (i == 1)
        {
            RewardInPanelUI.sprite = eventData.segondReward.visualItem;
            eventUIPanel.color = refColorEventNewReward.color;
            eventPointsWin.SetActive(false);
            eventUIEndSentenceText.SetActive(false);
            eventUINewRewardText.SetActive(true);
            eventUINewRewardPicture.SetActive(true);
            animationPanelEventPointWin.lockToMainAnim = true;
            animationPanelEventPointWin.launchNewRewardPanelAnimBool = true;
        }

        if (i == 2)
        {
            RewardInPanelUI.sprite = eventData.thirdReward.visualItem;
            eventUIPanel.color = refColorEventNewReward.color;
            eventPointsWin.SetActive(false);
            eventUIEndSentenceText.SetActive(false);
            eventUINewRewardText.SetActive(true);
            eventUINewRewardPicture.SetActive(true);
            animationPanelEventPointWin.lockToMainAnim = true;
            animationPanelEventPointWin.launchNewRewardPanelAnimBool = true;
        }

        if (i == 3)
        {
            RewardInPanelUI.sprite = eventData.lastReward.visual;
            eventUIPanel.color = refColorEventNewReward.color;
            eventPointsWin.SetActive(false);
            eventUIEndSentenceText.SetActive(false);
            eventUINewRewardText.SetActive(true);
            eventUINewRewardPicture.SetActive(true);
            animationPanelEventPointWin.lockToMainAnim = true;
            animationPanelEventPointWin.launchNewRewardPanelAnimBool = true;
            
        }
    }

    public void TakeReward(int i)
    {
        if (i == 0)
        {
            CheckFirstReward.SetActive(true);
            PrintRewardTakePanel(contentEventList[GameManager.instance.idCurrentEvent], i);
            modificationOfInventory.AddItem(contentEventList[GameManager.instance.idCurrentEvent].firstReward);
            openPanels.CloseAllPanel();
            openPanels.OpenEventRewardPanel();
        }
        if (i == 1)
        {
            CheckSegondReward.SetActive(true);
            PrintRewardTakePanel(contentEventList[GameManager.instance.idCurrentEvent], i);
            modificationOfInventory.AddItem(contentEventList[GameManager.instance.idCurrentEvent].segondReward);
            openPanels.CloseAllPanel();
            openPanels.OpenEventRewardPanel();
        }
        if (i == 2)
        {
            CheckThirdReward.SetActive(true);
            PrintRewardTakePanel(contentEventList[GameManager.instance.idCurrentEvent], i);
            modificationOfInventory.AddItem(contentEventList[GameManager.instance.idCurrentEvent].thirdReward);
            openPanels.CloseAllPanel();
            openPanels.OpenEventRewardPanel();
        }
        if (i == 3)
        {
            CheckLastReward.SetActive(true);
            PrintRewardTakePanel(contentEventList[GameManager.instance.idCurrentEvent], i);
            modificationOfCollectionOfCats.AddCat(contentEventList[GameManager.instance.idCurrentEvent].lastReward);
            openPanels.CloseAllPanel();
            openPanels.OpenEventRewardPanel();
        }
    }

    public void PrintRewardTakePanel(EventData eventData, int i)
    {
        if (i == 0)
        {
            rewardTakeVisualInPanel.sprite = eventData.firstReward.visualItem;
            RewardTakeNameInPanel.text = eventData.firstReward.name;
        }
        if (i == 1)
        {
            rewardTakeVisualInPanel.sprite = eventData.segondReward.visualItem;
            RewardTakeNameInPanel.text = eventData.segondReward.name;
        }
        if (i == 2)
        {
            rewardTakeVisualInPanel.sprite = eventData.thirdReward.visualItem;
            RewardTakeNameInPanel.text = eventData.thirdReward.name;
        }
        if (i == 3)
        {
            rewardTakeVisualInPanel.sprite = eventData.lastReward.visual;
            RewardTakeNameInPanel.text = eventData.lastReward.nameOfCat;
        }

    }

    private void Update()
    {

        playerEventPointText.text = DataPlayer.instance.currentEventPoint.ToString();
        if (DataPlayer.instance.currentEventPoint > maxEventPoint)
        {
            DataPlayer.instance.currentEventPoint = maxEventPoint;
        }
        else
        {
            sliderEvent.SetCurrentEventPoint(DataPlayer.instance.currentEventPoint);
        }

    }
}


