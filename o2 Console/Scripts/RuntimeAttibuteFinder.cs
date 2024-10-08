using InGame_Console.InGame_Console_System.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RuntimeAttributeFinder : MonoBehaviour
{
    [SerializeField] bool RunOnSceneChanges = true;

    void Awake()
    {
        SceneManager.activeSceneChanged += OnSceneChanged;
    }

    void OnSceneChanged(Scene arg0, Scene arg1)
    {
        if (RunOnSceneChanges)
            FindAttributesInScene();
    }

    public static void FindAttributesInScene()
    {
        Debug.Log("Searching For Attributes In Scene");
        foreach (var monoBehaviour in FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None))
            ConsoleDatabase.RegisterClient(monoBehaviour);
    }
}