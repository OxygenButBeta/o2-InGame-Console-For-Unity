using System;
using UnityEngine;
using UnityEngine.UI;

public class Line : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI MessageText;
    [SerializeField] Image[] MsgColorImages;

    public void SetText(string str, Color color)
    {
        MessageText.text = FormatStr(str);
        MessageText.color = color;
        foreach (var img in MsgColorImages)
            img.color = color;
    }

    string FormatStr(string str)
    {
        return $"<color=white> [{DateTime.Now:HH:mm:ss}]</color> : " + str;
    }
}