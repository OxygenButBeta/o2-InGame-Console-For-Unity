using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Linq;
using InGame_Console.InGame_Console_System.Scripts;
using UnityEngine.UI;

public class ConsoleInputHandler : MonoBehaviour
{
    [SerializeField] O2_IGConsole console;

    [Header("UI Elements")] [SerializeField]
    Transform suggestionParent;

    [SerializeField] TMP_InputField CommandInputField;
    [SerializeField] Button submitButton;

    [Header("Key Bindings")] [SerializeField]
    KeyCode[] SubmitKeys = new[] { KeyCode.KeypadEnter, KeyCode.Return };

    [SerializeField] KeyCode[] consoleToggleKeyCodes = new[] { KeyCode.BackQuote, KeyCode.F1 };

    [Header("Suggestion Settings")] [SerializeField]
    int maxSuggestions = 5;

    [SerializeField] GameObject suggestionPrefab;


    bool suggestionsDestroyed;
    List<GameObject> suggestions;

    void Awake()
    {
        suggestions = new List<GameObject>(maxSuggestions);
        CommandInputField.onValueChanged.AddListener(OnCommandTextValueChanged);
        DontDestroyOnLoad(transform.parent);
    }

    void Update()
    {
        if (consoleToggleKeyCodes.Any(Input.GetKeyDown)) console.gameObject.SetActive(!console.gameObject.activeSelf);
        if (!console.gameObject.activeSelf)
            return;
        if (SubmitKeys.Any(Input.GetKeyDown)) SubmitCommand();
    }

    public void SubmitCommand()
    {
        if (string.IsNullOrEmpty(CommandInputField.text))
            return;

        var command = CommandDataResolver.ParseRawCommand(CommandInputField.text);
        CommandInputField.text = "";
        CommandInvoker.InvokeCommand(command.Command, command.DataKey);
    }

    void OnCommandTextValueChanged(string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            if (!suggestionsDestroyed)
                suggestions.ForEach(Destroy);
            submitButton.interactable = false;
            return;
        }

        submitButton.interactable = true;
        suggestions.ForEach(Destroy);
        suggestionsDestroyed = true;
        suggestions.Clear();
        CreateSuggestion(str);
        suggestionsDestroyed = false;
    }

    void CreateSuggestion(string searchString)
    {
        foreach (var commandName in ConsoleDatabase.GetAllCommands())
            if (commandName.ToLower().Contains(searchString.ToLower()))
            {
                if (suggestions.Count >= maxSuggestions) return;
                var suggestion = Instantiate(suggestionPrefab, suggestionParent);
                suggestion.GetComponent<SuggestionLine>()
                    .SetText(commandName, ConsoleDatabase.GetCommandType(commandName) ?? typeof(void),
                        CommandInputField);
                suggestions.Add(suggestion);
            }
    }
}