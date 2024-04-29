using UnityEngine.SceneManagement;
using UnityEngine;
using Unity.VisualScripting;

public class DontDestroyOnLoadScene : MonoBehaviour
{
    public GameObject[] objects;
    public CurrentSceneManager currentSceneManager;
    public string Main_Page;


    private void Awake()
    {
        if (currentSceneManager.isPlayerPresentByDefault == true)
        {

            foreach (var element in objects)
            {

                DontDestroyOnLoad(element);
            }

            SceneManager.LoadScene(Main_Page);


        }
        else
        {
            foreach (var element in objects)
            {

                DontDestroyOnLoad(element);
            }
        }

    }

    public void RemoveFromDontDestroyOnLoad()
    {
        foreach (var element in objects)
        {
            SceneManager.MoveGameObjectToScene(element,SceneManager.GetActiveScene());
        }
    }
}
