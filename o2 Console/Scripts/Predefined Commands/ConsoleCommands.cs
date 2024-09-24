using UnityEngine;

namespace InGame_Console.InGame_Console_System.Scripts.Predefined_Commands
{
    internal class ConsoleCommands
    {
        static O2_IGConsole console => Object.FindAnyObjectByType<O2_IGConsole>();

        [ConsoleCommand("/TestConsole.RandomLog")]
        static void RandomLog(int count)
        {
            for (var i = 0; i < count; i++)
                Debug.Log(
                    "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy");
        }

        [ConsoleCommand("/Clear")]
        static void ClearConsole()
        {
            console?.ClearConsole();
        }

        [ConsoleCommand("/Close")]
        static void CloseConsole()
        {
            Object.FindAnyObjectByType<O2_IGConsole>()?.gameObject.SetActive(false);
        }

        [ConsoleCommand("/Help")]
        static void Help()
        {
            Debug.Log("Available Commands : ");
            Debug.Log("Clear : Clears the console");
            Debug.Log("Close : Closes the console");
            Debug.Log("Time.Scale <float> : Sets the time scale of the game");
            Debug.Log("Application.Quit : Quits the application");
            Debug.Log("For More...");
            Debug.Log("Commands.ListAll : Lists all available commands");
        }

        [ConsoleCommand("Commands.ListAll")]
        static void ListAllCommands()
        {
            ConsoleUI.LogAsHeader("Available Commands");
            foreach (var command in ConsoleDatabase.GetAllCommands())
                Debug.Log(command);
        }

        [ConsoleCommand("Commands.ReBind")]
        static void ReBindCommands()
        {
            RuntimeAttributeFinder.FindAttributesInScene();
            Debug.Log("ConsoleCommand are rebinded");
        }
    }
}