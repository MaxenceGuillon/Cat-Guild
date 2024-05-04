using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class DataPlayer : MonoBehaviour
{
    public int coinsCount;
    public Text coinsCountText;
    public Text coinsCountMarket;

    public int AdventureCount = 0 ;
    public int maxAdventure;

    public Image experienceUI;
    public Text playerLvlText;
    public Text playerExpText;
    public int playerLvl = 1;
    public float currentXp = 0;
    public float maxXp = 100;
    public float rateXp = 1.2f;

    public Image energieUI;
    public Text playerEnergieText;
    public float currentEnergie = 100;
    public float maxEnergie = 100;

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

    private void Start()
    {
        experienceUI = GameObject.Find("CurrentExp").GetComponent<Image>();
        playerLvlText = GameObject.Find("LevelText").GetComponent<Text>();

        energieUI = GameObject.Find("CurrentEnergie").GetComponent<Image>();
        playerEnergieText = GameObject.Find("EnergieText").GetComponent<Text>();


    }

    private void Update()
    {
        coinsCountText.text = coinsCount.ToString();
        coinsCountMarket.text = coinsCount.ToString();
        playerExpText.text = currentXp.ToString() + "/" + maxXp;
        playerEnergieText.text = currentEnergie.ToString() + "/" + maxEnergie;

        float percentageExp = ((currentXp * 100) / maxXp) / 100;
        experienceUI.fillAmount = percentageExp;

        float percentageEnergie = ((currentEnergie * 100) / maxEnergie) / 100;
        energieUI.fillAmount = percentageEnergie;

        if ( Input.GetKeyDown(KeyCode.L) ) currentXp += 60;
        if (Input.GetKeyDown(KeyCode.L)) currentEnergie = currentEnergie - 25;

        if (currentXp >= maxXp) 
        {
            float reste = currentXp - maxXp;
            playerLvl += 1;
            playerLvlText.text = "Level : " + playerLvl.ToString();
            currentXp = 0 + reste;
            maxXp = RoundValue(maxXp * rateXp, 0.1f); ;
        }

        if (currentEnergie > maxEnergie)
        {
            currentEnergie = maxEnergie;
        }
        if (currentEnergie < 0)
        {
            currentEnergie = 0;
        }
    }

    public static float RoundValue(float num, float precision)
    {
        return Mathf.Floor(num * precision + 0.5f) / precision;
    }
    public void AddCoins(int count)
    {
        coinsCount += count;
    }

    public void NextAdventure()
    {
        AdventureCount ++;
    }
}

