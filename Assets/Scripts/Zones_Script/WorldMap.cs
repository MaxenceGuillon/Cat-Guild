using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Map_Scene ( in GameObject : MapPanel )

public class WorldMap : MonoBehaviour
{
    public List<GameObject> lockIconsList = new List<GameObject>(); //List of lock icons for every zone

    public string nameOfScene; // Adventure_Scene load when player clic on zone button

    private void Awake()
    {
        // Check whitch zone is lock or unlock when player arrive in Map_Scene
        for (int i = 0; i < GameManager.instance.numberOfZone; i++)
        {
            if (GameManager.instance.zonesUnlockList[i] == true) lockIconsList[i].SetActive(false);
            if (GameManager.instance.zonesUnlockList[i] == false) lockIconsList[i].SetActive(true);
        }
    }

    public void ChooseZone( int i)
    {
        GameManager.instance.iDZoneChoose = i;
        nameOfScene = "Adventure_Scene";
        SceneManager.LoadScene(nameOfScene);
        GameManager.instance.inMapScene = false;
        GameManager.instance.inAdventureScene = true;
    }
}
