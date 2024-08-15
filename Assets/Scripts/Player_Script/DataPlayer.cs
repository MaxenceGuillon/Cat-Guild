using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;
using Unity.Mathematics;

// Loading_Scene ( in GameObject : DataPlayer ) 

public class DataPlayer : MonoBehaviour
{
    // Coins variables
    public int coinsCount;
    public Text coinsCountText;
    public Text coinsCountMarket;

    // Adventure variables
    public int AdventureCount = 0 ;
    public int maxAdventure;

    // Experience and level variables
    public Image experienceUI;
    public Text playerLvlText;
    public Text playerExpText;
    public int playerLvl = 1;
    public float currentXp = 0;
    public float maxXp = 100;
    public float rateXp = 1.2f;

    // Energy variables
    public Image energyUI;
    public Text playerEnergyText;
    public float currentEnergy = 100;
    public float maxEnergy = 100;
    public bool lockProgress = false;

    // Event variables
    public int currentEventPoint = 0;
    public int maxEventPoint;
    public bool triggerNewEvent = false;
    public bool checkerEvent = false;


    public static DataPlayer instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance d'inventaire dans la scène");
            return;
        }
        instance = this;
    }

    // Set UI player's data on start of game 
    private void Start()
    {
        experienceUI = GameObject.Find("CurrentExp").GetComponent<Image>();
        playerLvlText = GameObject.Find("LevelText").GetComponent<Text>();

        energyUI = GameObject.Find("CurrentEnergie").GetComponent<Image>();
        playerEnergyText = GameObject.Find("EnergieText").GetComponent<Text>();
    }

    // Update UI player's data in game
    private void Update()
    {
        coinsCountText.text = coinsCount.ToString();
        coinsCountMarket.text = coinsCount.ToString();
        playerExpText.text = currentXp.ToString() + "/" + maxXp;
        playerEnergyText.text = currentEnergy.ToString() + "/" + maxEnergy;

        float percentageExp = ((currentXp * 100) / maxXp) / 100;
        experienceUI.fillAmount = percentageExp;

        float percentageEnergie = ((currentEnergy * 100) / maxEnergy) / 100;
        energyUI.fillAmount = percentageEnergie;

        if ( Input.GetKeyDown(KeyCode.L) ) currentXp += 60;
        if (Input.GetKeyDown(KeyCode.L)) currentEnergy = currentEnergy - 33;
        if (Input.GetKeyDown(KeyCode.L)) currentEventPoint = currentEventPoint + 25;

        if (currentXp >= maxXp) 
        {
            float reste = currentXp - maxXp;
            playerLvl += 1;
            playerLvlText.text = "Level : " + playerLvl.ToString();
            currentXp = 0 + reste;
            maxXp = math.trunc(maxXp * rateXp);
        }

        if (currentEnergy > maxEnergy) currentEnergy = maxEnergy;
        if (currentEnergy < 0) currentEnergy = 0;

        if ((GameManager.instance.eventNow == true) && (checkerEvent == false))
        {
            triggerNewEvent = true;
            DataPlayer.instance.currentEventPoint = 0;
            checkerEvent = true;
        }
    }

    public void AddCoins(int count)
    {
        coinsCount += count;
    }

    public void NextAdventure()
    {
        AdventureCount ++;
    }

    public void EnergyModification(float number)
    {
        if (currentEnergy + number < 0) lockProgress = true;
        else currentEnergy = currentEnergy + number;
    }

    public void EventPointWin(int eventPointAdd)
    {
        if (currentEventPoint + eventPointAdd > maxEventPoint)
        {
            currentEventPoint = maxEventPoint;
            return;
        }
        currentEventPoint = currentEventPoint + eventPointAdd;
    }
}

