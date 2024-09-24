using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ConsoleUI : MonoBehaviour, IDragHandler
{
    [SerializeField] RectTransform _rectTransform;
    [SerializeField] TMP_Text HeaderText;

    void Awake()
    {
        HeaderText.text = "[o2 Console v1.O] // " + Application.productName;
    }

    public static void LogAsHeader(string message)
    {
        Debug.Log("<b><color=green>" + "-----------" + message + "-----------" + " </color><b>");
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta;
    }

    [ConsoleCommand("Width")]
    void SetWidth(int width)
    {
        _rectTransform.sizeDelta = new Vector2(width, _rectTransform.sizeDelta.y);
    }

    [ConsoleCommand("Height")]
    void SetHeight(float height)
    {
        _rectTransform.sizeDelta = new Vector2(_rectTransform.sizeDelta.x, height);
    }
}