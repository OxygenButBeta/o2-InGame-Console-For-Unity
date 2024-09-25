using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class SuggestionLine : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] TMP_Text suggestionText;
    [SerializeField] TMP_Text TypeText;
    TMP_InputField _textField;
    Type _commandType;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_commandType == typeof(void)) _textField.text = "<color=orange>" + suggestionText.text + "()</color>";
        else _textField.text = "<color=orange>" + suggestionText.text + "</color>: ";
    }

    public void SetText(string CommandKey, Type reType, TMP_InputField _textFieldInput)
    {
        _commandType = reType;
        TypeText.text = reType is not null ? reType.ToString().Split(".")[1] : "null";
        if (TypeText.text.Length > 11) TypeText.text = TypeText.text[..11] + "..";

        _textField = _textFieldInput;
        suggestionText.text = CommandKey;
    }
}