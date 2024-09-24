using System.Collections.Generic;
using UnityEngine;


public class O2_IGConsole : MonoBehaviour
{
    [SerializeField] int MaxLogCount = 100;
    [SerializeField] GameObject linePrefab;
    [SerializeField] Transform logParent;
    List<Line> lines;
    LogType LastType = LogType.Assert;

    void Awake()
    {
        lines = new List<Line>(MaxLogCount);

        ClearConsole();
        Application.logMessageReceivedThreaded += HandleLog;
    }

    public void ClearConsole()
    {
        for (var i = 0; i < logParent.childCount; i++) Destroy(logParent.GetChild(i).gameObject);

        lines.Clear();
    }

    void Start()
    {
        HandleLog(
            "<b> O2_IGConsole is initialized and ready to use <b>", null, LogType.Log);
        HandleLog(
            "<b>Type 'Close_Console' to close the console. and 'Clear' to clear the console. For more commands type '<b>Help<b>'",
            null, LogType.Log);
    }

    void OnDestroy()
    {
        Application.logMessageReceivedThreaded -= HandleLog;
    }

    void HandleLog(string condition, string stacktrace, LogType _type)
    {
        var color = Color.white;
        switch (_type)
        {
            case LogType.Warning:
                color = Color.yellow;
                break;
            case LogType.Error:
                color = Color.red;
                break;
            case LogType.Exception:
                color = Color.red;
                break;
        }

        if (LastType == LogType.Log && _type == LogType.Log)
        {
            color = new Color(0.45f, 0.71f, 0.55f);
            LastType = LogType.Assert;
        }
        else
        {
            LastType = _type;
        }

        var line = Instantiate(linePrefab, logParent).GetComponent<Line>();
        line.SetText(condition, color);
        lines.Add(line);

        if (lines.Count < MaxLogCount) return;
        Destroy(lines[0].gameObject);
        lines.RemoveAt(0);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}