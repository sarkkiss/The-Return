using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Player player;

    public InputField textEntryField;
    public Text logText;
    public Text CurrentText;

    public Action[] actions;

    [TextArea]
    public string introText;


    // Start is called before the first frame update
    void Start()
    {
        logText.text = introText;
        DisplayLocation();
        textEntryField.ActivateInputField();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayLocation(bool additive = false)
    {
        string description = player.currentLocation.description + "\n";
        description += player.currentLocation.GetConnectionsText();
        description += player.currentLocation.getItemsText();
        if (additive)
            CurrentText.text = CurrentText.text + "\n" + description;
        else
            CurrentText.text = description;
    }

    public void TextEntered()
    {
        LogCurrentText();
        ProcessInput(textEntryField.text);
        textEntryField.text = "";
        textEntryField.ActivateInputField();

    }

    void LogCurrentText()
    {
        logText.text += "\n\n";
        logText.text += CurrentText.text;

        logText.text += "\n\n";
        logText.text += "<color=#aaccaaff>" + textEntryField.text + "</color>";
    }

    void ProcessInput(string input)
    {
        input = input.ToLower();

        char[] delimiter = { ' ' };
        string[] separatedWords = input.Split(delimiter);

        foreach (Action a in actions)
        {
            if (a.keyword.ToLower() == separatedWords[0])
            {
                if (separatedWords.Length > 1)
                {
                    a.RespondToInput(this, separatedWords[1]);
                }
                else
                {
                    a.RespondToInput(this, "");
                }
                return;
            }
        }

        CurrentText.text = "Nothing happens! (having trouble? type Help)";
    }
}
