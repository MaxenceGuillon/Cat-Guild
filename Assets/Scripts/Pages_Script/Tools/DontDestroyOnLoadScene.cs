using UnityEngine.SceneManagement;
using UnityEngine;
using Unity.VisualScripting;

// Loading_Scene ( in GameObject : GameManager / DontDestroyOnLoad )

public class DontDestroyOnLoadScene : MonoBehaviour
{
    public string main_page;
    public GameObject[] objects;

    // Keep some elements in all scenes
    private void Awake()
    {
        foreach (var element in objects)
        {
            DontDestroyOnLoad(element);
        }
        if (GameManager.instance.inLoadingScene == true)
        {
            SceneManager.LoadScene(main_page);
            GameManager.instance.inLoadingScene = false;
        }
    }

    // No necessary now, but if we need destroy one element in DontDestroyOnLoad list
    public void RemoveFromDontDestroyOnLoad()
    {
        foreach (var element in objects)
        {
            SceneManager.MoveGameObjectToScene(element,SceneManager.GetActiveScene());
        }
    }
}
