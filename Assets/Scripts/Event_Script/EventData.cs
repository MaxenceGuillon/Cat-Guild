using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Event", menuName = "Event/newEvent")]

public class EventData : ScriptableObject 
{
    //Main

    public string eventName;
    public int eventIndex;
    public Sprite eventConcept;
    public string descriptionOfEvent;

    
    public int maxEventPoint = 100;


    // Rewards

    public ItemData firstReward;
    public ItemData segondReward;
    public ItemData thirdReward;
    public CatData lastReward;

    public int eventFirstButtonId;
    public int eventSegondButtonId;
    public int eventThirdButtonId;
    public int eventFourthButtonId;
    public int eventFifthButtonId;
    public int eventSixthButtonId;

    //Points

    public int marketPoint;
    public int tournamentPoint;
    public int roulettePoint;
    public int addCat;
    public int activitiesPoint;
    public int questPoint;

}


