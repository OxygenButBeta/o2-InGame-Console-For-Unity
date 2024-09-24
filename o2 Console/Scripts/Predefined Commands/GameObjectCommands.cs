using UnityEngine;

namespace InGame_Console.InGame_Console_System.Scripts.Predefined_Commands
{
    public class GameObjectCommands
    {
        [ConsoleCommand("GameObject.LoadAndSpawn")]
        static void SpawnObject(GameObject @object)
        {
            Debug.Log("Spawned " + @object.name);
            Object.Instantiate(@object);
        }

        [ConsoleCommand("GameObject.ToggleGameObject")]
        static void ToggleGameObject(string @object)
        {
            var obj = GameObject.Find(@object);
            if (obj != null)
                obj.SetActive(!obj.activeSelf);
            else
                Debug.LogError($"GameObject with name {@object} not found.");
        }

        [ConsoleCommand("GameObject.DestroyObject")]
        static void DestroyObject(string @object)
        {
            var obj = GameObject.Find(@object);
            if (obj != null)
                Object.Destroy(obj);
            else
                Debug.LogError($"GameObject with name {@object} not found.");
        }

        [ConsoleCommand("GameObject.Clone")]
        static void CloneGameObject(string @object)
        {
            var obj = GameObject.Find(@object);
            if (obj != null)
                Object.Instantiate(obj);
            else
                Debug.LogError($"GameObject with name {@object} not found.");
        }
    }
}