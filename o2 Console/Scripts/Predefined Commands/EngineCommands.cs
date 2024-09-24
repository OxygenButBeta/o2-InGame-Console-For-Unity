using UnityEditor;
using UnityEngine;
using InGame_Console.InGame_Console_System.Scripts;


internal static partial class EngineCommands
{
    [ConsoleCommand("Application.Quit")]
    static void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    [ConsoleCommand("Time.Scale")]
    static float TimeScale
    {
        get => Time.timeScale;
        set => Time.timeScale = value;
    }


    [ConsoleCommand("Debug.Log")]
    static void PrintLog(string LogMessage)
    {
        Debug.Log(LogMessage);
    }

    [ConsoleCommand("Physics.SetGravity")]
    static void SetGravity(float gravityValue)
    {
        Physics.gravity = new Vector3(0, gravityValue, 0);
    }

    [ConsoleCommand("Camera.SetFOV")]
    static void SetFOV(float fovValue)
    {
        var camera = Camera.main;
        if (camera != null)
            camera.fieldOfView = fovValue;
        else
            Debug.LogError("Main Camera not found.");
    }

    [ConsoleCommand("Scene.LoadScene")]
    static void LoadScene(string sceneName)
    {
        if (!string.IsNullOrEmpty(sceneName))
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        else
            Debug.LogError("Invalid scene name.");
    }

    [ConsoleCommand("Audio.SetVolume")]
    static void SetVolume(float volumeLevel)
    {
        AudioListener.volume = Mathf.Clamp01(volumeLevel);
    }

    [ConsoleCommand("Graphics.SetQualityLevel")]
    static void SetQualityLevel(int level)
    {
        QualitySettings.SetQualityLevel(level);
    }

    [ConsoleCommand("Screen.SetFullscreen")]
    static void SetFullscreen(bool mode)
    {
        Screen.fullScreen = mode;
    }

    [ConsoleCommand("Screen.SetResolution")]
    static void SetResolution(string resolution)
    {
        var split = resolution.Split('x');
        if (split.Length == 2 && int.TryParse(split[0], out var width) && int.TryParse(split[1], out var height))
            Screen.SetResolution(width, height, Screen.fullScreen);
        else
            Debug.LogError("Invalid resolution format. Use 'widthxheight' format (e.g., 1920x1080).");
    }
}